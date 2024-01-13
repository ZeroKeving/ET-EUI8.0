namespace ET.Server
{
    /// <summary>
    /// Gate会话钥匙组件系统
    /// </summary>
    [FriendOf(typeof(GateSessionKeyComponent))]
    public static partial class GateSessionKeyComponentSystem
    {
        public static void Add(this GateSessionKeyComponent self, long key, LoginGateInfoProto loginGateInfoProto)
        {
            self.sessionKey.Add(key, loginGateInfoProto);
            self.TimeoutRemoveKey(key).Coroutine();//20秒后移除该账号的登录钥匙
        }

        public static LoginGateInfoProto Get(this GateSessionKeyComponent self, long key)
        {
            LoginGateInfoProto loginGateInfoProto = null;
            self.sessionKey.TryGetValue(key, out loginGateInfoProto);
            return loginGateInfoProto;
        }

        public static void Remove(this GateSessionKeyComponent self, long key)
        {
            self.sessionKey.Remove(key);
        }

        private static async ETTask TimeoutRemoveKey(this GateSessionKeyComponent self, long key)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(20000);
            self.sessionKey.Remove(key);
        }
    }
}