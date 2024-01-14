namespace ET.Server;

/// <summary>
/// 顶号和多次登录标识组件系统
/// </summary>
[EntitySystemOf(typeof(MultiLoginComponent))]
[FriendOfAttribute(typeof(ET.Server.MultiLoginComponent))]
public static partial class MultiLoginComponentSystem
{
    
    [EntitySystem]
    private static void Awake(this ET.Server.MultiLoginComponent self)
    {
        //启动定时器任务，顶号时上个角色保留时间
        self.Timer_Over = self.Root().GetComponent<TimerComponent>()
                .NewOnceTimer(TimeInfo.Instance.ServerNow() + (20 * 1000), TimerInvokeType.MultiLogin, self);
    }
    [EntitySystem]
    private static void Destroy(this ET.Server.MultiLoginComponent self)
    {
        self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer_Over);//关闭定时器任务
    }
    
    /// <summary>
    /// 顶号和多次登录标识组件定时器任务
    /// </summary>
    [Invoke(TimerInvokeType.MultiLogin)]
    public class MultiLoginComponent_TimerHandler: ATimer<MultiLoginComponent>
    {
        protected override void Run(MultiLoginComponent t)
        {
            //以协程的方式执行下线逻辑
            t.GetParent<GateUser>()?.OfflineWithLock(false).Coroutine();
        }
    }
}