namespace ET.Server;

/// <summary>
/// 角色信息数据
/// </summary>
[ChildOf(typeof(AccountZoneDB))]
public class RoleInfoDB : Entity,IAwake,IDestroy
{
    public string Account;
    public long AcountZoneId;//账号区服id
    public bool IsDeleted;//当前角色是否有被删除掉
    public string Name;//角色名称
    public int Level;//角色等级
}