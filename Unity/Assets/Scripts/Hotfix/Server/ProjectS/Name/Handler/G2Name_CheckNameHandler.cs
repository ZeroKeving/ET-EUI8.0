using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ET.Server;

/// <summary>
/// Gate服务器向Name名字查重服务器发送获取查重名字消息处理
/// </summary>
[MessageHandler(SceneType.Name)]
[FriendOfAttribute(typeof(ET.Server.CheckNameLog))]
public class G2Name_CheckNameHandler : MessageHandler<Scene, G2Name_CheckName, Name2G_CheckName>
{
    protected override async ETTask Run(Scene root, G2Name_CheckName request, Name2G_CheckName response)
    {
        if (!Regex.IsMatch(request.Name.Trim(), @"^([\u4e00-\u9fa5]{1,8}|[a-zA-Z0-9]{1,16})$")) //判断名称是否为混合输入的1~8位的中文或是1~16位的数字和英文
        {
            response.Error = ErrorCode.ERR_Name_RoleNameFormError;
            return;
        }

        using (await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.CheckName, request.Name.GetLongHashCode()))
        {
            DBComponent dbComponent = root.GetDirectDB();
            List<CheckNameLog> list = await dbComponent.Query<CheckNameLog>(d => d.Name == request.Name);//查询名字

            if (list.Count > 0)
            {
                response.Error = ErrorCode.ERR_Name_RoleNameRepeated;//角色名称重复
                return;
            }

            using (CheckNameLog checkNameLog = root.GetComponent<TempComponent>().AddChild<CheckNameLog>())//创建一个新的角色名
            {
                checkNameLog.Name = request.Name;
                checkNameLog.UnitId = request.UnitId;
                checkNameLog.CreateTime = TimeInfo.Instance.ServerNow();
                await dbComponent.Save(checkNameLog);//存储这个角色名
            }
            
        }

    }
}