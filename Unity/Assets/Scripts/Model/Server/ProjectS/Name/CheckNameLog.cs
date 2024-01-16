namespace ET.Server;

/// <summary>
/// 查重角色日志
/// </summary>
[ChildOf(typeof(TempComponent))]
public class CheckNameLog : Entity,IAwake,IDestroy
{
    public string Name;//游戏角色名称
    public long UnitId;//游戏角色id
    public long CreateTime;//游戏角色创建时间
}