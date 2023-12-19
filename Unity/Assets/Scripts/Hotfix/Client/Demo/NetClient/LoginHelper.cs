namespace ET.Client
{
    public static class LoginHelper
    {
        /// <summary>
        /// 登录游戏
        /// </summary>
        /// <param name="root"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public static async ETTask Login(Scene root, string account, string password)
        {
            //删除客户端通讯组件又重新添加客户端通信组件，是为了保证每次登录都要创建一个全新的登录连接
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();

            //从服务器获取玩家登录信息
            long playerId = await clientSenderCompnent.LoginAsync(account, password);

            root.GetComponent<PlayerComponent>().MyId = playerId;
            
            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
        }
    }
}