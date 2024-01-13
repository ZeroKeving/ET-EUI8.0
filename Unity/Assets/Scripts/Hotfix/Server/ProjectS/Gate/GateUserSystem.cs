namespace ET.Server;

/// <summary>
/// Gate用户
/// </summary>
[EntitySystemOf(typeof(GateUser))]
[FriendOf(typeof(GateUser))]
public static partial class GateUserSystem
{
    [EntitySystem]
    private static void Awake(this ET.Server.GateUser self)
    {

    }
    [EntitySystem]
    private static void Destroy(this ET.Server.GateUser self)
    {
        
    }
}