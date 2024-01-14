namespace ET.Client;

/// <summary>
/// 角色信息组件
/// </summary>
[ChildOf(typeof(RoleInfosComponent))]
public class RoleInfo : Entity,IAwake,IDestroy
{
    public string Name;//角色名称
    public int Level;//角色等级
}