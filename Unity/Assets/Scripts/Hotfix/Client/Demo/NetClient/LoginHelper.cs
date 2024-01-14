using System;

namespace ET.Client
{
    [FriendOf(typeof(ServerInfosComponent))]
    [FriendOf(typeof(ServerInfo))]
    [FriendOfAttribute(typeof(ET.Client.RoleInfosComponent))]
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
            //从服务器获取玩家登录信息
            NetClient2Main_LoginGame response = await root.GetComponent<ClientSenderCompnent>().LoginGameAsync(account, password);

            if (response.Error != ErrorCode.ERR_Success) //如果登录失败，则返回错误码
            {
                Log.Error("response Error:" + response.Error);
                return response.Error;
            }

            root.GetComponent<ServerInfosComponent>().ClearServerInfo(); //先清空所有游戏区服
            foreach (ServerListInfoProto serverListInfoProto in response.ServerListInfosProto) //遍历添加所有游戏区服
            {
                root.GetComponent<ServerInfosComponent>().AddServerInfo(serverListInfoProto);
            }

            root.GetComponent<PlayerComponent>().RealmToken = response.Token;

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="root"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public static async ETTask<int> Register(Scene root, string account, string password1, string password2)
        {
            //从服务器获取玩家注册信息
            NetClient2Main_Register response = await root.GetComponent<ClientSenderCompnent>().RegisterAsync(account, password1, password2);

            if (response.Error != ErrorCode.ERR_Success) //如果注册失败，则返回错误码
            {
                Log.Error("response Error:" + response.Error);
                return response.Error;
            }

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 进入游戏
        /// </summary>
        /// <returns></returns>
        public static async ETTask<int> EnterGame(Scene root, string account, string password)
        {
            ServerInfosComponent serverInfosComponent = root.GetComponent<ServerInfosComponent>();
            if (serverInfosComponent == null)
            {
                return ErrorCode.ERR_Zone_ZoneNotFound; //未找到区服信息
            }

            //进入游戏
            NetClient2Main_EnterGame response = await root.GetComponent<ClientSenderCompnent>().EnterGameAsync(serverInfosComponent.ServerInfosList[serverInfosComponent.CurrentServerIndex].ServerZone, account, password);

            if (response.Error != ErrorCode.ERR_Success) //如果进入游戏失败，则返回错误码
            {
                Log.Error("response Error:" + response.Error);
                return response.Error;
            }

            int errorCode = await GetRoleInfos(root);//获取角色信息

            if (errorCode != ErrorCode.ERR_Success)//如果获取角色失败，则返回错误码
            {
                Log.Error("response Error:" + response.Error);
                return response.Error;
            }

            //await EventSystem.Instance.PublishAsync(root, new LoginFinish());

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 获取该账号在这个区服中所有的角色信息
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static async ETTask<int> GetRoleInfos(Scene root)
        {
            G2C_GateRoles response = (G2C_GateRoles)await root.GetComponent<ClientSenderCompnent>().Call(new C2G_GateRoles() { });

            if (response.Error != ErrorCode.ERR_Success) //如果获取角色信息失败，则返回错误码
            {
                Log.Error("response Error:" + response.Error);
                return response.Error;
            }

            RoleInfosComponent roleInfosComponent = root.GetComponent<RoleInfosComponent>();
            roleInfosComponent.ClearRoleInfos();//清空所有角色信息

            foreach (GetRoleInfoProto roleInfoProto in response.Roles)//添加所有角色信息
            {
                roleInfosComponent.AddRoleInfo(roleInfoProto);
            }

            return ErrorCode.ERR_Success;
        }
    }
}