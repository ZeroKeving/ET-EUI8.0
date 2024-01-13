using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// Gate网关会话钥匙组件
    /// </summary>
    [ComponentOf(typeof (Scene))]
    public class GateSessionKeyComponent: Entity, IAwake
    {
        public readonly Dictionary<long, LoginGateInfoProto> sessionKey = new();
    }
}