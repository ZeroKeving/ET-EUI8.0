namespace ET.Server
{
    /// <summary>
    /// 玩家实体
    /// </summary>
    [ChildOf(typeof(PlayerComponent))]
    public sealed class Player : Entity, IAwake<string>
    {
        public string Account { get; set; }
    }
}