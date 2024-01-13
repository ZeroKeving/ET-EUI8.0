using System;

namespace ET.Server;

/// <summary>
/// 断开连接助手类
/// </summary>
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
    public static async ETTask<CoroutineLock> GetGateUserLock(Scene root,string account)
    {
        if (string.IsNullOrEmpty(account))
        {
            throw new Exception("LoginHelper : GetGateUserLock but account is Null !");
        }

        return await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.GateUserLock, account.GetLongHashCode());
    }
}