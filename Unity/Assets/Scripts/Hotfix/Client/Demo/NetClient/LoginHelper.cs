using CommandLine;

namespace ET.Client
{
    public static class LoginHelper
    {
        /// <summary>
        /// 登录游戏(Demo用法)
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

        /// <summary>
        /// 登录游戏
        /// </summary>
        /// <param name="root"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public static async ETTask<int> LoginGame(Scene root, string account, string password)
        {
            //删除客户端通讯组件又重新添加客户端通信组件，是为了保证每次登录都要创建一个全新的登录连接
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();

            //从服务器获取玩家登录信息
            NetClient2Main_LoginGame response = await clientSenderCompnent.LoginGameAsync(account, password);

            if (response.Error != ErrorCode.ERR_Success)//如果登录失败，则返回错误码
            {
                Log.Error("response Error:"+response.Error);
                return response.Error;
            }

            root.GetComponent<PlayerComponent>().MyId = response.PlayerId;
            
            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
            
            return ErrorCode.ERR_Success;
        }
        
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="root"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public static async ETTask<int> Register(Scene root, string account, string password)
        {
            //删除客户端通讯组件又重新添加客户端通信组件，是为了保证每次登录都要创建一个全新的登录连接
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();

            //从服务器获取玩家注册信息
            NetClient2Main_LoginGame response = await clientSenderCompnent.RegisterAsync(account, password);

            if (response.Error != ErrorCode.ERR_Success)//如果注册失败，则返回错误码
            {
                Log.Error("response Error:"+response.Error);
                return response.Error;
            }
            
            return ErrorCode.ERR_Success;
        }
    }
}