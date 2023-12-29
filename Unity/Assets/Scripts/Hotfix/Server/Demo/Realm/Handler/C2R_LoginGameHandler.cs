using System.Collections.Generic;

namespace ET.Server;

/// <summary>
/// 客户端与Realm网关服务器通讯的登录游戏消息处理
/// </summary>
[MessageSessionHandler(SceneType.Realm)]
[FriendOfAttribute(typeof(ET.Server.AccountInfo))]
public class C2R_LoginGameHandler : MessageSessionHandler<C2R_LoginGame, R2C_LoginGame>
{
    protected override async ETTask Run(Session session, C2R_LoginGame request, R2C_LoginGame response)
    {
        if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))//判断账号密码是否为空
        {
            response.Error = ErrorCode.ERR_LoginInfoNull;//返回登录信息错误码
            CloseSession(session).Coroutine();//延迟1秒后断开连接
            return;
        }

        //异步逻辑块
        using(await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount,request.Account.GetLongHashCode()))//协程锁，所有用户都会抢这把锁，传入唯一id，用户账号名的哈希值（防止不同地址的用户用相同的账号去登录）
        {
            DBComponent dbComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone());//传入区服信息id获取对应的数据库连接组件

            List<AccountInfo> accountInfos = await dbComponent.Query<AccountInfo>(accountInfo => accountInfo.Account == request.Account);//在数据库里查询账号信息

            //TO DO:未来需要把登录和注册分开
            if (accountInfos.Count <= 0)//如果没有查询到账号信息
            {
                AccountInfosComponent accountInfosComponent =
                        session.GetComponent<AccountInfosComponent>() ?? session.AddComponent<AccountInfosComponent>();//判断session身上是否有账号信息组件，如果没有则挂载这个组件
                AccountInfo accountInfo = accountInfosComponent.AddChild<AccountInfo>();//在账号信息组件下创建一个账号信息
                accountInfo.Account = request.Account;
                accountInfo.Password = request.Password;
                await dbComponent.Save(accountInfo);//将账号信息存入数据库
            }
            else
            {
                AccountInfo accountInfo = accountInfos[0];//取出第一个账号密码
                if (accountInfo.Password != request.Password)//如果密码错误
                {
                    response.Error = ErrorCode.ERR_LoginPasswordError;//登录密码错误
                    CloseSession(session).Coroutine();//延迟1秒后断开连接
                    return;
                }
            }
        }
        
        
        // 随机分配一个Gate
        StartSceneConfig config = RealmGateAddressHelper.GetGate(session.Zone(), request.Account);
        Log.Debug($"gate address: {config}");

        // 向gate请求一个key,客户端可以拿着这个key连接gate
        G2R_GetLoginKey g2RGetLoginKey = (G2R_GetLoginKey)await session.Fiber().Root.GetComponent<MessageSender>().Call(
            config.ActorId, new R2G_GetLoginKey() { Account = request.Account });

        response.Address = config.InnerIPPort.ToString();
        response.Key = g2RGetLoginKey.Key;
        response.GateId = g2RGetLoginKey.GateId;

        CloseSession(session).Coroutine();
    }

    private async ETTask CloseSession(Session session)
    {
        await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
        session.Dispose();
    }
}