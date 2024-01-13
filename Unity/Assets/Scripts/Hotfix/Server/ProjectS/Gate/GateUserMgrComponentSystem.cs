namespace ET.Server;

/// <summary>
/// Gate用户经理组件系统
/// </summary>
[EntitySystemOf(typeof(GateUserMgrComponent))]
[FriendOf(typeof(GateUserMgrComponent))]
public static partial class GateUserMgrComponentSystem
{
    [EntitySystem]
    private static void Awake(this ET.Server.GateUserMgrComponent self)
    {

    }
    [EntitySystem]
    private static void Destroy(this ET.Server.GateUserMgrComponent self)
    {
        self.Users.Clear();
    }
    
    
}