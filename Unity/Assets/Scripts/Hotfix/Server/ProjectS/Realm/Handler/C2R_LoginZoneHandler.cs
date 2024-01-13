using System;

namespace ET.Server;

/// <summary>
/// 客户端与Realm网关服务器通讯的登录区服游戏消息处理
/// </summary>
[MessageSessionHandler(SceneType.Realm)]
public class C2R_LoginZoneHandler: MessageSessionHandler<C2R_LoginZone, R2C_LoginZone>
{
    protected override async ETTask Run(Session session, C2R_LoginZone request, R2C_LoginZone response)
    {
        session.RemoveComponent<SessionAcceptTimeoutComponent>(); //移除连接5秒超时组件（代表连接通过了验证，如果没有通过验证该组件5秒后会断开连接）
        
        int modCount = Math.Abs(request.Account.GetHashCode() % StartSceneConfigCategory.Instance.Realms.Count); //对账号哈希值取模的绝对值

        if (session.Root().Id != StartSceneConfigCategory.Instance.Realms[modCount].Id) //该账号是否登录到正确的Realm服务器
        {
            response.Error = ErrorCode.ERR_RealmAdressError; //Realm服务器地址错误
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (!StartZoneConfigCategory.Instance.Contain(request.Zone))//区服id是否存在
        {
            response.Error = ErrorCode.ERR_Zone_ZoneNotFound;//找不到区服
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (session.Root().GetComponent<RealmTokenComponent>().Get(request.Account) != request.Token)//如果登录令牌不同
        {
            response.Error = ErrorCode.ERR_Zone_LoginTimeout;//令牌失效
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        using (await session.Root().GetComponent<CoroutineLockComponent>()
                       .Wait(CoroutineLockType.LoginZone,
                           request.Account.GetLongHashCode())) //协程锁，所有用户都会抢这把锁，传入唯一id，用户账号名的哈希值（防止不同地址的用户用相同的账号去登录）
        {
            //如果需要在给某个Scene实体发送网络消息的时候，先要拿到对应的StartSceneConfig，才能拿到config.ActorId，才能使用MessageSender.Call,来进行不同的Scene实体之间的网络消息通讯
            // 随机分配一个Gate
            StartSceneConfig config = RealmGateAddressHelper.GetGate(request.Zone, request.Account);
            Log.Debug($"gate address: {config}");
        
            // 向gate请求一个key,客户端可以拿着这个key连接gate
            G2R_GetLoginGameKey g2RGetLoginGameKey = (G2R_GetLoginGameKey)await session.Fiber().Root.GetComponent<MessageSender>()
                    .Call(config.ActorId, new R2G_GetLoginGameKey() { Info = new LoginGateInfoProto(){Account = request.Account ,Zone = request.Zone} });

            if (g2RGetLoginGameKey.Error != ErrorCode.ERR_Success)
            {
                response.Error = g2RGetLoginGameKey.Error;//返回错误码
                session.Disconnect().Coroutine(); //延迟1秒后断开连接
                return;
            }
        
            response.GateAddress = config.InnerIPPort.ToString();
            response.GateKey = g2RGetLoginGameKey.Key;
            response.GateId = g2RGetLoginGameKey.GateId;
        }
        
        session.Disconnect().Coroutine(); //延迟1秒后断开连接
    }
}