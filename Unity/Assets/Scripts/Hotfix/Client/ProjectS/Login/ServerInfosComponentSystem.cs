namespace ET.Client;

/// <summary>
/// 区服信息组件系统
/// </summary>
[EntitySystemOf(typeof(ServerInfosComponent))]
[FriendOf(typeof(ServerInfosComponent))]
[FriendOf(typeof(ServerInfo))]
public static partial class ServerInfosComponentSystem
{
    [EntitySystem]
    private static void Awake(this ET.Client.ServerInfosComponent self)
    {

    }
    
    /// <summary>
    /// 清除所有的游戏区服信息
    /// </summary>
    /// <param name="self"></param>
    public static void ClearServerInfo(this ServerInfosComponent self)
    {
        foreach (var serverInfo in self.ServerInfosList)
        {
            serverInfo?.Dispose();
        }
        self.ServerInfosList.Clear();
    }

    /// <summary>
    /// 添加游戏区服信息
    /// </summary>
    /// <param name="self"></param>
    /// <param name="serverListInfo"></param>
    public static void AddServerInfo(this ServerInfosComponent self, ServerListInfoProto serverListInfo)
    {
        ServerInfo serverInfo = self.AddChild<ServerInfo>();
        serverInfo.ServerZone = serverListInfo.Zone;
        serverInfo.ServerName = serverListInfo.Name;
        serverInfo.Status = serverListInfo.Status;
        self.ServerInfosList.Add(serverInfo);
    }
}