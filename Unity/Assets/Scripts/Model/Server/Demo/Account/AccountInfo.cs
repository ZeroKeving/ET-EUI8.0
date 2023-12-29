namespace ET.Server;

/// <summary>
/// 账号信息
/// </summary>
[ChildOf(typeof(AccountInfosComponent))]
public class AccountInfo : Entity,IAwake
{
    public string Account;//账号
    public string Password;//密码
}