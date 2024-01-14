namespace ET.Server;

/// <summary>
/// 角色信息数据系统
/// </summary>
[EntitySystemOf(typeof(RoleInfoDB))]
[FriendOfAttribute(typeof(ET.Server.RoleInfoDB))]
public static partial class RoleInfoDBSystem
{
    [EntitySystem]
    private static void Awake(this ET.Server.RoleInfoDB self)
    {

    }
    [EntitySystem]
    private static void Destroy(this ET.Server.RoleInfoDB self)
    {

    }

    public static GetRoleInfoProto ToMessage(this RoleInfoDB self)
    {
        return new GetRoleInfoProto() { UnitId = self.Id, Level = self.Level, Name = self.Name };
    }
}