namespace ET.Server;

/// <summary>
/// 顶号和多次登录标识组件
/// </summary>
[ComponentOf(typeof(GateUser))]
public class MultiLoginComponent : Entity,IAwake,IDestroy
{
    public long Timer_Over;
}