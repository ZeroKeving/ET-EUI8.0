using System.Threading.Tasks;

namespace ET.Client
{
    [EntitySystemOf(typeof(ClientSenderCompnent))]
    [FriendOf(typeof(ClientSenderCompnent))]
    public static partial class ClientSenderCompnentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientSenderCompnent self)
        {

        }
        
        [EntitySystem]
        private static void Destroy(this ClientSenderCompnent self)
        {
            self.RemoveFiberAsync().Coroutine();
        }

        private static async ETTask RemoveFiberAsync(this ClientSenderCompnent self)
        {
            if (self.fiberId == 0)
            {
                return;
            }

            int fiberId = self.fiberId;
            self.fiberId = 0;
            await FiberManager.Instance.Remove(fiberId);
        }

        /// <summary>
        /// 异步登录(Demo用法)
        /// </summary>
        /// <param name="self"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async ETTask<long> LoginAsync(this ClientSenderCompnent self, string account, string password)
        {
            //创建NetClient纤程
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            //创建NetClient的实体id
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);

            //两个纤程之间通信使用ProcessInnerSender
            NetClient2Main_Login response = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, new Main2NetClient_Login()
            {
                OwnerFiberId = self.Fiber().Id, Account = account, Password = password
            }) as NetClient2Main_Login;
            return response.PlayerId;
        }

        /// <summary>
        /// 创建NetClient纤程
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask CreatNetClientFiber(this ClientSenderCompnent self)
        {
            //创建NetClient纤程
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            //创建NetClient的实体id
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);
        }
        
        /// <summary>
        /// 异步登录游戏
        /// </summary>
        /// <param name="self"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async ETTask<NetClient2Main_LoginGame> LoginGameAsync(this ClientSenderCompnent self, string account, string password)
        {
            //两个纤程之间通信使用ProcessInnerSender
            NetClient2Main_LoginGame response = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, new Main2NetClient_LoginGame()
            {
                OwnerFiberId = self.Fiber().Id, Account = account, Password = password
            }) as NetClient2Main_LoginGame;
            return response;
        }
        
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="self"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async ETTask<NetClient2Main_Register> RegisterAsync(this ClientSenderCompnent self, string account, string password1, string password2)
        {
            //两个纤程之间通信使用ProcessInnerSender
            NetClient2Main_Register response = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, new Main2NetClient_Register()
            {
                OwnerFiberId = self.Fiber().Id, Account = account, Password1 = password1, Password2 = password2
            }) as NetClient2Main_Register;
            return response;
        }
        
        /// <summary>
        /// 进入游戏
        /// </summary>
        /// <param name="self"></param>
        /// <param name="Zone"></param>
        /// <returns></returns>
        public static async ETTask<NetClient2Main_EnterGame> EnterGameAsync(this ClientSenderCompnent self, int Zone, string account, string password)
        {
            //两个纤程之间通信使用ProcessInnerSender
            NetClient2Main_EnterGame response = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, new Main2NetClient_EnterGame()
            {
                OwnerFiberId = self.Fiber().Id, Zone = Zone,Account = account,Password = password,Token = self.Root().GetComponent<PlayerComponent>().RealmToken
            }) as NetClient2Main_EnterGame;
            return response;
        }

        public static void Send(this ClientSenderCompnent self, IMessage message)
        {
            A2NetClient_Message a2NetClientMessage = A2NetClient_Message.Create();
            a2NetClientMessage.MessageObject = message;
            self.Root().GetComponent<ProcessInnerSender>().Send(self.netClientActorId, a2NetClientMessage);
        }

        public static async ETTask<IResponse> Call(this ClientSenderCompnent self, IRequest request, bool needException = true)
        {
            A2NetClient_Request a2NetClientRequest = A2NetClient_Request.Create();
            a2NetClientRequest.MessageObject = request;
            A2NetClient_Response a2NetClientResponse = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, a2NetClientRequest) as A2NetClient_Response;
            IResponse response = a2NetClientResponse.MessageObject;
                        
            if (response.Error == ErrorCore.ERR_MessageTimeout)
            {
                throw new RpcException(response.Error, $"Rpc error: request, 注意Actor消息超时，请注意查看是否死锁或者没有reply: {request}, response: {response}");
            }

            if (needException && ErrorCore.IsRpcNeedThrowException(response.Error))
            {
                throw new RpcException(response.Error, $"Rpc error: {request}, response: {response}");
            }
            return response;
        }

    }
}