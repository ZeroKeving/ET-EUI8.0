using System.Collections.Generic;

namespace ET.Client;

/// <summary>
/// 游戏区服组件
/// </summary>
[ComponentOf(typeof(Scene))]
public class ServerInfosComponent: Entity, IAwake
{
    public List<ServerInfo> ServerInfosList = new List<ServerInfo>();//游戏区服实体列表

    public int CurrentServerIndex = 0;//当前玩家要进入的服务器索引
}