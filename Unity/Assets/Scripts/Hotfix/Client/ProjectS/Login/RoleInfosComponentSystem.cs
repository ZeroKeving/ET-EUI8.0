namespace ET.Client;

/// <summary>
/// 角色信息组件系统
/// </summary>
[EntitySystemOf(typeof(RoleInfosComponent))]
[FriendOfAttribute(typeof(ET.Client.RoleInfosComponent))]
[FriendOfAttribute(typeof(ET.Client.RoleInfo))]
public static partial class RoleInfosComponentSystem
{
    [EntitySystem]
    private static void Awake(this ET.Client.RoleInfosComponent self)
    {

    }
    [EntitySystem]
    private static void Destroy(this ET.Client.RoleInfosComponent self)
    {

    }

    /// <summary>
    /// 删除所有角色信息
    /// </summary>
    /// <param name="self"></param>
    public static void ClearRoleInfos(this RoleInfosComponent self)
    {
        foreach (RoleInfo roleInfo in self.RoleInfos)//释放所有角色信息实体
        {
            roleInfo?.Dispose();
        }
        self.RoleInfos.Clear();
    }

    /// <summary>
    /// 添加角色信息
    /// </summary>
    /// <param name="self"></param>
    public static void AddRoleInfo(this RoleInfosComponent self, GetRoleInfoProto roleInfoProto)
    {
        RoleInfo roleInfo = self.AddChildWithId<RoleInfo>(roleInfoProto.UnitId);//roleInfo.Id会被赋值为UnitId
        roleInfo.Name = roleInfoProto.Name;
        roleInfo.Level = roleInfoProto.Level;
        self.RoleInfos.Add(roleInfo);
    }
}