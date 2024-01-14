using System.Collections.Generic;

namespace ET.Server;

/// <summary>
/// Gate用户经理组件
/// </summary>
[ComponentOf(typeof(Scene))]
public class GateUserMgrComponent: Entity,IAwake,IDestroy
{
    public Dictionary<string, GateUser> Users = new Dictionary<string, GateUser>();
}