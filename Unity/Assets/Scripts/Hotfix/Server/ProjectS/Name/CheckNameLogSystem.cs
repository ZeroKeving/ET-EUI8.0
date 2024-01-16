namespace ET.Server;

/// <summary>
/// 查重角色日志系统
/// </summary>
[EntitySystemOf(typeof(CheckNameLog))]
[FriendOfAttribute(typeof(ET.Server.CheckNameLog))]
public static partial class CheckNameLogSystem
{
    [EntitySystem]
    private static void Awake(this ET.Server.CheckNameLog self)
    {

    }
    [EntitySystem]
    private static void Destroy(this ET.Server.CheckNameLog self)
    {
        self.Name = default;
        self.UnitId = default;
        self.CreateTime = default;
    }
}