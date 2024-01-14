namespace ET.Server;

/// <summary>
/// Gat用户状态
/// </summary>
public enum GateUserState
{
    InGate = 1,//在Gate网关服务器
    InQueue = 2,//在排队
    InMap = 3,//在游戏逻辑服务器
}

/// <summary>
/// Gate用户
/// </summary>
[ChildOf(typeof(GateUserMgrComponent))]
public class GateUser : Entity,IAwake,IDestroy
{
    public GateUserState State = GateUserState.InGate;//Gate用户状态
    
    private EntityRef<Session> session;//会话连接

    public Session Session
    {
        get
        {
            return this.session;
        }
        set
        {
            this.session = value;
        }
    }
}