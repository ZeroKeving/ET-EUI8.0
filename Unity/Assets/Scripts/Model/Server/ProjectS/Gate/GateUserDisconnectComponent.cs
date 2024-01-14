namespace ET.Server;

/// <summary>
/// 定时销毁Gate用户连接组件
/// </summary>
[ComponentOf(typeof(GateUser))]
public class GateUserDisconnectComponent : Entity,IAwake<long>,IDestroy
{
    public long Timer;
}