namespace ET.Server;

[EntitySystemOf(typeof(AccountInfo))]
[FriendOf(typeof(AccountInfo))]
public static partial class AccountInfosSystem
{
    [EntitySystem]
    private static void Awake(this AccountInfo self)
    {

    }
    [EntitySystem]
    private static void Destroy(this AccountInfo self)
    {
        self.Account = null;
        self.Password = null;
        self.CreateTime = 0;
        self.AccountTye = 0;
    }
}