using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    /// <summary>
    /// Main纤程与NetClient纤程通讯的登录消息处理
    /// </summary>
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_LoginHandler: MessageHandler<Scene, Main2NetClient_Login, NetClient2Main_Login>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_Login request, NetClient2Main_Login response)
        {
            string account = request.Account;
            string password = request.Password;
            // 创建一个ETModel层的Session
            root.RemoveComponent<RouterAddressComponent>();//移除路由节点地址组件，保证每次登录获取新的路由节点地址
            // 获取路由跟realm服务器地址
            //设定软路由服务器的地址和端口
            RouterAddressComponent routerAddressComponent =
                    root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
            await routerAddressComponent.Init();//请求RouterMananger服务器，来获取一系列的路由节点地址
            //给NetClient添加网络组件
            root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily, NetworkProtocol.UDP);
            //把记录MainFiberId记录在纤程父对象组件
            root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

            NetComponent netComponent = root.GetComponent<NetComponent>();
            
            //获取Realm网关负载均衡服务器地址
            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

            //通过Router节点服务器建立和Realm网关负载驱动服务器连接
            R2C_Login r2CLogin;
            using (Session session = await netComponent.CreateRouterSession(realmAddress, account, password))
            {
                r2CLogin = (R2C_Login)await session.Call(new C2R_Login() { Account = account, Password = password });
            }

            //通过Router节点服务器建立和Gate网关负载驱动服务器连接
            // 创建一个gate Session,并且保存到SessionComponent中
            Session gateSession = await netComponent.CreateRouterSession(NetworkHelper.ToIPEndPoint(r2CLogin.Address), account, password);
            gateSession.AddComponent<ClientSessionErrorComponent>();
            root.AddComponent<SessionComponent>().Session = gateSession;
            //请求登录Gate网关服务器
            G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId });

            Log.Debug("登陆gate成功!");

            response.PlayerId = g2CLoginGate.PlayerId;
        }
    }
}