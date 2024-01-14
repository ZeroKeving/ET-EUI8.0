using ET.Client;

namespace ET.Server;

/// <summary>
/// 客户端向Gate网关服务器发起获取角色信息消息处理
/// </summary>
[MessageSessionHandler(SceneType.Gate)]
public class C2G_GateRolesHandler : MessageSessionHandler<C2G_GateRoles, G2C_GateRoles>
{
    protected override async ETTask Run(Session session, C2G_GateRoles request, G2C_GateRoles response)
    {
        GateUser gateUser = session.GetComponent<SessionUserComponent>()?.User;
        
        if(gateUser == null)//如果没有Gate用户说明没有通过Gate网关登录流程
        {
            response.Error = ErrorCode.ERR_Gate_NoGateUser;
            return;
        }

        AccountZoneDB accountZoneDB = gateUser.GetComponent<AccountZoneDB>();//获取区服账号信息
        
        if(accountZoneDB == null)
        {
            response.Error = ErrorCode.ERR_Gate_NoAccountZoneDB;
            return;
        }

        if (accountZoneDB.Children.Count > 0)
        {
            foreach (Entity entity in accountZoneDB.Children.Values)//遍历所有角色信息子实体
            {
                if (entity is RoleInfoDB roleInfoDB)
                {
                    response.Roles.Add(roleInfoDB.ToMessage());
                }
            }
        }

        await ETTask.CompletedTask;
    }
}