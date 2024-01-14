namespace ET.Server;

/// <summary>
/// 账号区服数据
/// </summary>
[ComponentOf(typeof(GateUser))]
public class AccountZoneDB : Entity,IAwake,IDestroy
{
    public string Account;
    public int LoginZoneId;//区服id
}