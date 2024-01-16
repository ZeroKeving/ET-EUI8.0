using System.Text.RegularExpressions;
using ET.Client;

namespace ET.Server;

/// <summary>
/// 客户端向Gate网关服务器发起创建角色消息处理
/// </summary>
[MessageSessionHandler(SceneType.Gate)]
[FriendOfAttribute(typeof (ET.Server.RoleInfoDB))]
[FriendOfAttribute(typeof (ET.Server.AccountZoneDB))]
public class C2G_CreateRoleHandler: MessageSessionHandler<C2G_CreateRole, G2C_CreateRole>
{
    protected override async ETTask Run(Session session, C2G_CreateRole request, G2C_CreateRole response)
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
        
        if (accountZoneDB.Children.Count > 0)
        {
            int i = 0;
            foreach (Entity entity in accountZoneDB.Children.Values)//遍历所有角色信息子实体
            {
                if (entity is RoleInfoDB roleInfoDB)//统计已经创建了多少个角色
                {
                    if (!roleInfoDB.IsDeleted)//如果该角色没被删除
                    {
                        i = i + 1;
                    }
                }
            }

            if (i >= SystemValueConfigCategory.Instance.SystemValueDict["MaxRoleInfoCreate"][0])//如果该区服下拥有的角色超过或等于最大可创建角色时
            {
                response.Error = ErrorCode.ERR_Gate_RoleMax;//已达可创建的最大角色上限
                return;
            }
        }

        if (!Regex.IsMatch(request.Name.Trim(), @"^([\u4e00-\u9fa5]{1,8}|[a-zA-Z0-9]{1,16})$")) //判断名称是否为混合输入的1~8位的中文或是1~16位的数字和英文
        {
            response.Error = ErrorCode.ERR_Gate_RoleNameFormError;
            return;
        }

        long instanceId = accountZoneDB.InstanceId;

        using (await gateUser.GetGateUserLock()) //协程锁，所有用户都会抢这把锁，传入唯一id，用户账号名的哈希值（防止不同地址的用户用相同的账号去登录）
        {
            if (instanceId != accountZoneDB.InstanceId)
            {
                response.Error = ErrorCode.ERR_Gate_NoAccountZoneDB;
                return;
            }

            long unitId = IdGenerater.Instance.GenerateInstanceId();

            //向角色名称查重服务器查询名称是否重复
            Name2G_CheckName name2G_CheckName = (Name2G_CheckName)await ServerMessageHelper.CallActor(session.Root(), accountZoneDB.LoginZoneId,
                "Name", new G2Name_CheckName() { Name = request.Name, UnitId = unitId });
            
            if (name2G_CheckName.Error != ErrorCode.ERR_Success)//名称重复
            {
                response.Error = name2G_CheckName.Error;
                return;
            }

            RoleInfoDB roleInfoDB = accountZoneDB.AddChildWithId<RoleInfoDB>(unitId); //创建一个角色信息数据
            roleInfoDB.Account = accountZoneDB.Account;
            roleInfoDB.AcountZoneId = accountZoneDB.Id; //如果需要游戏角色转服，可以更改这个值
            roleInfoDB.LogicZone = accountZoneDB.LoginZoneId;
            roleInfoDB.IsDeleted = false;
            roleInfoDB.Name = request.Name;
            roleInfoDB.Level = 1;
            roleInfoDB.CreateTime = TimeInfo.Instance.ServerNow();

            await session.GetDirectDB().Save(roleInfoDB); //将角色信息数据存入数据库中

            response.Role = roleInfoDB.ToMessage();
        }
    }
}