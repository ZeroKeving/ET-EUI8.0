using System.Collections.Generic;

namespace ET.Client;

/// <summary>
/// 角色信息组件
/// </summary>
[ComponentOf(typeof(Scene))]
public class RoleInfosComponent : Entity,IAwake,IDestroy
{
    public List<RoleInfo> RoleInfos = new List<RoleInfo>();
}