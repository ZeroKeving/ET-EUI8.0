namespace ET.Server;

//游戏账号类型
public enum AccountTye
{
    General = 0,//普通玩家
    BlackList = 100,//黑名单玩家
}

/// <summary>
/// 账号信息
/// </summary>
[ChildOf(typeof(AccountInfosComponent))]
public class AccountInfo : Entity,IAwake,IDestroy
{
    public string Account = default;//账号
    public string Password = default;//密码
    public long CreateTime = default;//账号创建时间
    public int AccountTye = default;//账号类型
}