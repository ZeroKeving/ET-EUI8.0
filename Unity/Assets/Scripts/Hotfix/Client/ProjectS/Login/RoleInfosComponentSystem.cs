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

    /// <summary>
    /// 通过索引获取角色信息
    /// </summary>
    /// <param name="self"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static RoleInfo GetRoleInfoByIndex(this RoleInfosComponent self,int index)
    {
        if (index < 0 || index >= self.RoleInfos.Count)
        {
            return null;
        }

        return self.RoleInfos[index];
    }

    /// <summary>
    /// 删除游戏角色信息
    /// </summary>
    /// <param name="self"></param>
    /// <param name="roleId"></param>
    public static void DeleteRoleInfoById(this RoleInfosComponent self,long roleId)
    {
        int index = self.RoleInfos.FindIndex((RoleInfo) => { return RoleInfo.Id == roleId; });
        
        self.RoleInfos.RemoveAt(index);
    }
    
}