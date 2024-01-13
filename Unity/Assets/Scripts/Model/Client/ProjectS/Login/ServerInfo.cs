namespace ET.Client;

/// <summary>
/// 游戏区服状态
/// </summary>
public enum ServerStatus
{
    Active = 0,//激活状态
    Close = 1,//关闭状态
}

/// <summary>
/// 游戏区服信息
/// </summary>
[ChildOf(typeof(ServerInfosComponent))]
public class ServerInfo : Entity,IAwake
{
    public int ServerZone;//区服id
    public string ServerName;//区服名字
    public int Status;//区服状态
}