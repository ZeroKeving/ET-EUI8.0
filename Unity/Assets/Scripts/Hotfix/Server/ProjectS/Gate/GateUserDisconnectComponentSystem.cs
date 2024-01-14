namespace ET.Server;

/// <summary>
/// 定时销毁Gate用户连接组件系统
/// </summary>
[EntitySystemOf(typeof(GateUserDisconnectComponent))]
[FriendOf(typeof(GateUserDisconnectComponent))]
public static partial class GateUserDisconnectComponentSystem
{
    [EntitySystem]
    private static void Awake(this ET.Server.GateUserDisconnectComponent self, long time)
    {
        //创建一个定时器任务，在时间到后将其下线
        self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeInfo.Instance.ServerNow() + time,TimerInvokeType.GateUserDisconnect,self);
    }
    [EntitySystem]
    private static void Destroy(this ET.Server.GateUserDisconnectComponent self)
    {
        self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);//销毁计时器
    }
    
    /// <summary>
    /// 顶号者长时间不继续登录的下线定时器任务
    /// </summary>
    [Invoke(TimerInvokeType.GateUserDisconnect)]
    public class GateUserDisconnectComponent_TimerHandler : ATimer<GateUserDisconnectComponent>
    {
        protected override void Run(GateUserDisconnectComponent t)
        {
            t.GetParent<GateUser>().OfflineWithLock().Coroutine();//对内下线,并释放Gate用户实体
        }
    }
}