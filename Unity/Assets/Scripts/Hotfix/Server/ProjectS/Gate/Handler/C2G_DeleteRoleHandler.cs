using ET.Client;

namespace ET.Server;

/// <summary>
/// 客户端向Gate网关服务器发起删除角色消息处理
/// </summary>
[MessageSessionHandler(SceneType.Gate)]
[FriendOfAttribute(typeof(ET.Server.RoleInfoDB))]
public class C2G_DeleteRoleHandler : MessageSessionHandler<C2G_DeleteRole, G2C_DeleteRole>
{
    protected override async ETTask Run(Session session, C2G_DeleteRole request, G2C_DeleteRole response)
    {
        GateUser gateUser = session.GetComponent<SessionUserComponent>()?.User;

        if (gateUser == null) //如果没有Gate用户说明没有通过Gate网关登录流程
        {
            response.Error = ErrorCode.ERR_Gate_NoGateUser;
            return;
        }

        AccountZoneDB accountZoneDB = gateUser.GetComponent<AccountZoneDB>(); //获取区服账号信息

        if (accountZoneDB == null)
        {
            response.Error = ErrorCode.ERR_Gate_NoAccountZoneDB;
            return;
        }

        if (!accountZoneDB.Children.ContainsKey(request.RoleId))//如果不能获取到要删除的角色信息
        {
            response.Error = ErrorCode.ERR_Gate_NoRole;//未找到需要删除的角色
            return;
        }

        long instanceId = accountZoneDB.InstanceId;

        using (await gateUser.GetGateUserLock())
        {
            if (instanceId != accountZoneDB.InstanceId)
            {
                response.Error = ErrorCode.ERR_Gate_NoAccountZoneDB;
                return;
            }

            RoleInfoDB roleInfoDB = accountZoneDB.Children[request.RoleId] as RoleInfoDB;//获取角色信息数据

            if (roleInfoDB == null)
            {
                response.Error = ErrorCode.ERR_Gate_NoRoleDB;//未找到需要删除的角色
                return;
            }

            roleInfoDB.IsDeleted = true;

            DBComponent dbComponent = session.GetDirectDB();
            await dbComponent.Save(roleInfoDB);//存入角色删除数据
            response.RoleId = roleInfoDB.Id;
            roleInfoDB.Dispose();//释放被删除的角色信息

        }

    }
}