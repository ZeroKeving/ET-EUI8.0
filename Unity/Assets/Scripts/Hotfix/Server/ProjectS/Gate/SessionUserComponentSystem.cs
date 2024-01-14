namespace ET.Server;

/// <summary>
/// 当前Session对应的Gate用户组件系统(有这个组件代表当前连接是完成了登录网关流程，后续网络消息通讯为合法的)
/// </summary>
[FriendOf(typeof(SessionUserComponent))]
[EntitySystemOf(typeof(SessionUserComponent))]
public static partial class SessionUserComponentSystem
{
    [EntitySystem]
    private static void Awake(this SessionUserComponent self)
    {

    }
    [EntitySystem]
    private static void Destroy(this SessionUserComponent self)
    {
        GateUser gateUser = self.User;
        if (gateUser != null && self.GetParent<Session>().IsDisposed)//如果主动断开Session会被主动移除
        {
            //如果是主动断开，应该先移除SessionUserComponent,再销毁Session,否则就认为是突然断开了
            gateUser.AddComponent<GateUserDisconnectComponent, long>(ConstValue.Login_SessionDisconnectTime);//Session突然断开一段时间后没重连就下线
        }

        // self.User = null;
        //
        // Scene root = self.Root();
        // if (root.IsDisposed)
        // {
        //     return;
        // }
        // //发送断线消息
        // root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(self.User.Id, new G2M_SessionDisconnect());
    }
}