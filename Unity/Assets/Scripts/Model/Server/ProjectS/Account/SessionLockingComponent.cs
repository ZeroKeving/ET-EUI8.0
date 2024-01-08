namespace ET.Server;

/// <summary>
/// 会话锁组件（用来防止同一用户发起多次会话请求）
/// </summary>
[ComponentOf(typeof(Session))]
public class SessionLockingComponent : Entity,IAwake
{
    
}