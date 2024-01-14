namespace ET.Server;

/// <summary>
/// 当前Session对应的Gate用户组件(有这个组件代表当前连接是完成了登录网关流程，后续网络消息通讯为合法的)
/// </summary>
[ComponentOf(typeof(Session))]
public class SessionUserComponent : Entity,IAwake,IDestroy
{
    private EntityRef<GateUser> user;

    public GateUser User
    {
        get
        {
            return this.user;
        }
        set
        {
            this.user = value;
        }
    }
}