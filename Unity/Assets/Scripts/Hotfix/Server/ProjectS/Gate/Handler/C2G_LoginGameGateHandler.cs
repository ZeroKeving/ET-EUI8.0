using System.Collections.Generic;

namespace ET.Server;

/// <summary>
/// 客户端向Gate网关服务器发起登录游戏消息处理(MessageSessionHandler,是针对与游戏客户端需要直接连接到某一类型的服务器上时才会用到，并且会产生一个对应的Session，后续建立Player和Unit后不再使用)
/// </summary>
[MessageSessionHandler(SceneType.Gate)]
[FriendOf(typeof (GateUser))]
[FriendOf(typeof (AccountZoneDB))]
[FriendOf(typeof (RoleInfoDB))]
public class C2G_LoginGameGateHandler: MessageSessionHandler<C2G_LoginGameGate, G2C_LoginGameGate>
{
    protected override async ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response)
    {
        session.RemoveComponent<SessionAcceptTimeoutComponent>(); //移除连接5秒超时组件（代表连接通过了验证，如果没有通过验证该组件5秒后会断开连接）

        Scene root = session.Root();

        GateSessionKeyComponent gateSessionKeyComponent = root.GetComponent<GateSessionKeyComponent>();
        LoginGateInfoProto loginGateInfoProto = gateSessionKeyComponent.Get(request.GateKey); //从发过来的登录钥匙，获取到登录账号
        if (loginGateInfoProto == null) //如果登录信息为空
        {
            response.Error = ErrorCode.ERR_Gate_NotLoginGateInfo;
            return;
        }

        string account = loginGateInfoProto.Account;

        //TO DO 判断停服，维护，封号，ip等等的情况

        long instanceId = session.InstanceId;

        using (await LoginHelper.GetGateUserLock(session.Root(), account)) //协程锁，所有用户都会抢这把锁，传入唯一id，用户账号名的哈希值（防止不同地址的用户用相同的账号去登录）
        {
            if (instanceId != session.InstanceId) //如果不为同一个会话连接时直接断开
            {
                return;
            }

            GateUserMgrComponent gateUserMgrComponent = root.GetComponent<GateUserMgrComponent>(); //获取Gate用户经理组件
            GateUser gateUser = gateUserMgrComponent.Get(account); //获取Gate用户

            if (gateUser == null) //如果没有获取到，就从数据库中查询
            {
                DBComponent dbComponent = root.GetDirectDB();
                List<AccountZoneDB> list = await dbComponent.Query<AccountZoneDB>(d => d.Account == account); //查找该账号区服数据

                if (list.Count == 0) //新账号
                {
                    gateUser = gateUserMgrComponent.Create(account, loginGateInfoProto.Zone);
                    await gateUser.AddLocation(LocationType.Player); //通知Loaction定位服务器，告知当前实体所在的具体位置
                }
                else //老账号
                {
                    gateUser = gateUserMgrComponent.Create(list[0]);
                    await gateUser.AddLocation(LocationType.Player); //通知Loaction定位服务器，告知当前实体所在的具体位置
                }

                long id = gateUser.GetComponent<AccountZoneDB>().Id; //获取账号区服数据的id

                List<RoleInfoDB> roleInfoDbs = await dbComponent.Query<RoleInfoDB>(d => d.AcountZoneId == id && !d.IsDeleted); //查询该区服下所有没有被删除的角色id

                if (roleInfoDbs.Count > 0)//如果有角色信息
                {
                    foreach (RoleInfoDB roleInfoDB in roleInfoDbs)//遍历所有角色
                    {
                        gateUser.GetComponent<AccountZoneDB>().AddChild(roleInfoDB);//将所有角色添加到账号区服数据下
                    }
                }
            }
            else//如果获取到Gate用户
            {
                gateUser.RemoveComponent<GateUserDisconnectComponent>();//去除掉定时销毁组件
                gateUser.RemoveComponent<MultiLoginComponent>();//移除掉顶号和多次登录标识组件(移除下线定时器可以防止多次触发下线登录逻辑)
            }

            //玩家实体和会话完成一一映射关系
            gateUser.Session = session;//连接到新的Session
            session.AddComponent<SessionUserComponent>().User = gateUser;//在会话上添加会话Gate用户组件

            if (gateUser.State != GateUserState.InGate)//如果该用户不在Gate状态，代表其他玩家正在登录
            {
                gateUser.AddComponent<MultiLoginComponent>();//添加顶号和多次登录标识组件(会将正在登录的玩家进行下线流程)
            }
            
            response.PlayerId = gateUser.Id;
            
        }

        
        //
        // PlayerComponent playerComponent = root.GetComponent<PlayerComponent>(); //获取玩家组件
        // Player player = playerComponent.GetByAccount(account); //获取玩家实体
        // if (player == null) //如果未获取到，代表客户端第一次连接到Gate网关服务器
        // {
        //     player = playerComponent.AddChild<Player, string>(account); //创建一个玩家
        //     playerComponent.Add(player); //将玩家实体，添加进玩家组件中
        //     PlayerSessionComponent playerSessionComponent = player.AddComponent<PlayerSessionComponent>(); //将玩家添加玩家会话组件
        //     playerSessionComponent
        //             .AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.GateSession); //在玩家会话组件里添加一个邮箱组件,添加处理网络消息的能力（只能处理对应邮箱类型的网络消息）
        //     await playerSessionComponent.AddLocation(LocationType.GateSession); //通知Loaction定位服务器，告知当前实体所在的具体位置
        //
        //     player.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage); //在玩家实体里添加添加一个邮箱组件,添加处理网络消息的能力（只能处理对应邮箱类型的网络消息）
        //     await player.AddLocation(LocationType.Player); //通知Loaction定位服务器，告知当前实体所在的具体位置
        //
        //     //玩家实体和会话完成一一映射关系
        //     session.AddComponent<SessionPlayerComponent>().Player = player; //在会话上添加会话玩家组件
        //     playerSessionComponent.Session = session; //在玩家会话组件上记录一下会话
        // }
        // else
        // {
        //     //Room为帧同步案例
        //     // 判断是否在战斗
        //     PlayerRoomComponent playerRoomComponent = player.GetComponent<PlayerRoomComponent>();
        //     if (playerRoomComponent.RoomActorId != default)
        //     {
        //         CheckRoom(player, session).Coroutine();
        //     }
        //     else
        //     {
        //         //玩家实体和会话完成一一映射关系
        //         PlayerSessionComponent playerSessionComponent = player.GetComponent<PlayerSessionComponent>();
        //         playerSessionComponent.Session = session; //原本身上的会话已经过期，把新的会话记录一下
        //     }
        // }
        //
        // response.PlayerId = PlayerId.Id;
        await ETTask.CompletedTask;
    }

    private static async ETTask CheckRoom(Player player, Session session)
    {
        Fiber fiber = player.Fiber();
        await fiber.WaitFrameFinish();

        using Room2G_Reconnect room2GateReconnect = await fiber.Root.GetComponent<MessageSender>().Call(
            player.GetComponent<PlayerRoomComponent>().RoomActorId,
            new G2Room_Reconnect() { PlayerId = player.Id }) as Room2G_Reconnect;
        G2C_Reconnect g2CReconnect = new() { StartTime = room2GateReconnect.StartTime, Frame = room2GateReconnect.Frame };
        g2CReconnect.UnitInfos.AddRange(room2GateReconnect.UnitInfos);
        session.Send(g2CReconnect);

        session.AddComponent<SessionPlayerComponent>().Player = player;
        player.GetComponent<PlayerSessionComponent>().Session = session;
    }
}