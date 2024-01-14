using System;

namespace ET.Server;

/// <summary>
/// 断开连接助手类
/// </summary>
[FriendOfAttribute(typeof(ET.Server.AccountZoneDB))]
[FriendOfAttribute(typeof(ET.Server.GateUser))]
public static class LoginHelper
{
    /// <summary>
    /// 针对会话进行扩展，延迟1秒后断开连接
    /// </summary>
    /// <param name="self"></param>
    public static async ETTask Disconnect(this Session self)
    {
        if (self == null || self.IsDisposed)//判断会话是否为空或是被断开
        {
            return;
        }

        long instanceId = self.InstanceId;//记录一下会话id

        await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);//等待1秒

        if (self.InstanceId != instanceId)//判断当前会话的id是否等于之前会话的id，不等于直接返回
        {
            return;
        }

        self.Dispose();
    }

    /// <summary>
    /// 获取Gate用户协程锁
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public static async ETTask<CoroutineLock> GetGateUserLock(Scene root, string account)
    {
        if (string.IsNullOrEmpty(account))
        {
            throw new Exception("LoginHelper : GetGateUserLock but account is Null !");
        }

        return await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.GateUserLock, account.GetLongHashCode());
    }

    /// <summary>
    /// 获取Gate用户协程锁
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static ETTask<CoroutineLock> GetGateUserLock(this GateUser self)
    {
        AccountZoneDB accountZoneDB = self.GetComponent<AccountZoneDB>();
        return GetGateUserLock(self.Root(), accountZoneDB.Account);
    }

    /// <summary>
    /// 带锁下线（对内下线）
    /// </summary>
    /// <param name="self"></param>
    /// <param name="dispose"></param>
    public static async ETTask OfflineWithLock(this GateUser self, bool dispose = true)
    {
        if (self == null || self.IsDisposed)
        {
            return;
        }

        long instanceId = self.InstanceId;

        using (await self.GetGateUserLock())//协程锁
        {
            if (instanceId != self.InstanceId)//如果实例id发生变化直接返回
            {
                return;
            }
            //执行下线逻辑
            await self.Offline(dispose);
        }
    }

    /// <summary>
    /// 下线（对内下线）
    /// </summary>
    /// <param name="self"></param>
    /// <param name="dispose"></param>
    public static async ETTask Offline(this GateUser self, bool dispose = true)
    {
        if (self == null || self.IsDisposed)
        {
            return;
        }

        AccountZoneDB accountZoneDB = self.GetComponent<AccountZoneDB>();
        if (accountZoneDB != null)//不为空，说明角色已经登录进游戏
        {
            //TO DO：通知排队服务器进行角色下线 通知Map场景服务器角色进行下线
        }

        if (dispose)//是否释放
        {
            self.Root().GetComponent<GateUserMgrComponent>()?.Remove(accountZoneDB?.Account);
        }
        else//重置状态
        {
            self.State = GateUserState.InGate;
        }

        await ETTask.CompletedTask;
    }

    /// <summary>
    /// 下线会话（对外下线）
    /// </summary>
    public static void OfflineSession(this GateUser self)
    {
        Log.Console($"{self.GetComponent<AccountZoneDB>()?.Account} 被顶号 {self.Session.InstanceId} 对外下线");
        Session session = self.Session;

        if (session != null)
        {
            //发送给原先连接的客户端一条顶号下线消息“您的账号被顶下线了”
            session.Send(new ALL2C_Disconnect(){Error = ErrorCode.Hint_Login_MultiLogin});
            
            session.RemoveComponent<SessionUserComponent>();//移除后代表该会话非法，后续发来的消息不会再进行处理
            session.Disconnect().Coroutine();//1秒后断开连接
        }

        self.Session = null;
        
        //为了防止后续玩家一直不登录，这里就加一个计时器，到时间了顶号的还不上来就对内下线了
        self.RemoveComponent<GateUserDisconnectComponent>();//防止重复添加
        self.AddComponent<GateUserDisconnectComponent,long>(ConstValue.Login_GateUserDisconnectTime);
        
    }
}