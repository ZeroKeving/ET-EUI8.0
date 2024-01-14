namespace ET.Server;

/// <summary>
/// Gate用户经理组件系统
/// </summary>
[EntitySystemOf(typeof(GateUserMgrComponent))]
[FriendOf(typeof(GateUserMgrComponent))]
[FriendOfAttribute(typeof(ET.Server.AccountZoneDB))]
public static partial class GateUserMgrComponentSystem
{
    [EntitySystem]
    private static void Awake(this GateUserMgrComponent self)
    {

    }
    [EntitySystem]
    private static void Destroy(this GateUserMgrComponent self)
    {
        self.Users.Clear();
    }

    /// <summary>
    /// 获取Gate用户
    /// </summary>
    /// <param name="self"></param>
    /// <param name="account"></param>
    /// <returns></returns>
    public static GateUser Get(this GateUserMgrComponent self, string account)
    {
        self.Users.TryGetValue(account, out GateUser gateUser);
        return gateUser;
    }

    /// <summary>
    /// 创建Gate用户
    /// </summary>
    /// <param name="self"></param>
    /// <param name="account"></param>
    /// <param name="zone"></param>
    /// <returns></returns>
    public static GateUser Create(this GateUserMgrComponent self, string account, int zone)
    {
        GateUser gateUser = self.AddChild<GateUser>();

        AccountZoneDB accountZoneDB = gateUser.AddComponent<AccountZoneDB>();//添加账号区服数据
        accountZoneDB.Account = account;
        accountZoneDB.LoginZoneId = zone;
        gateUser.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);//在玩家实体里添加添加一个邮箱组件,添加处理网络消息的能力（只能处理对应邮箱类型的网络消息）
        
        self.GetDirectDB().Save(accountZoneDB).Coroutine();//存入账号区服数据

        self.Users.Add(account, gateUser);//将新建的Gate用户加入列表

        return gateUser;
    }

    /// <summary>
    /// 创建Gate用户
    /// </summary>
    /// <param name="self"></param>
    /// <param name="accountZoneDB"></param>
    /// <returns></returns>
    public static GateUser Create(this GateUserMgrComponent self, AccountZoneDB accountZoneDB)
    {
        GateUser gateUser = self.AddChild<GateUser>();

        gateUser.AddComponent(accountZoneDB);//将账号区服数据添加入Gate用户
        gateUser.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);//在玩家实体里添加添加一个邮箱组件,添加处理网络消息的能力（只能处理对应邮箱类型的网络消息）

        self.Users.Add(accountZoneDB.Account, gateUser);//将新建的Gate用户加入列表

        return gateUser;
    }

    /// <summary>
    /// 移除
    /// </summary>
    /// <param name="self"></param>
    /// <param name="account"></param>
    public static void Remove(this GateUserMgrComponent self,string account)
    {
        GateUser gateUser = self.Get(account);
        if (gateUser == null)
        {
            return;
        }

        self.Users.Remove(account);
        gateUser.Dispose();
    }
}