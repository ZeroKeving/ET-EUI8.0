using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace ET.Client;

/// <summary>
/// Main纤程与NetClient纤程通讯的登录游戏消息处理
/// </summary>
[MessageHandler(SceneType.NetClient)]
public class Main2NetClient_LoginGameHandler:MessageHandler<Scene, Main2NetClient_LoginGame, NetClient2Main_LoginGame>
{
    protected override async ETTask Run(Scene root, Main2NetClient_LoginGame request, NetClient2Main_LoginGame response)
    {
            string account = request.Account;
            string password = request.Password;
            // 创建一个ETModel层的Session
            root.RemoveComponent<RouterAddressComponent>();//移除路由节点地址组件，保证每次登录获取新的路由节点地址
            // 获取路由跟realmDispatcher地址
            RouterAddressComponent routerAddressComponent = root.GetComponent<RouterAddressComponent>();
            if (routerAddressComponent == null)
            { 
                //设定软路由服务器的地址和端口
                routerAddressComponent =
                        root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                await routerAddressComponent.Init();//请求RouterMananger服务器，来获取一系列的路由节点地址
                //给NetClient添加网络组件
                root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily, NetworkProtocol.UDP);
                //把记录MainFiberId记录在纤程父对象组件
                root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;
            }

            NetComponent netComponent = root.GetComponent<NetComponent>();
            
            //根据账号取模来获取Realm网关负载均衡服务器地址（为什么用账号取模？如果有两个玩家同时注册账号，用的账号一致，就可以使账号连接同一个服务器，来保证唯一性）
            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

            //通过Router节点服务器建立和Realm网关负载驱动服务器连接
            R2C_LoginGame r2CLoginGame;
            using (Session session = await netComponent.CreateRouterSession(realmAddress, account, password))
            {
                r2CLoginGame = (R2C_LoginGame)await session.Call(new C2R_LoginGame() { Account = account, Password = password ,LoginWay = (int)LoginWayType.Normal});//使用普通账号密码登录
            }

            if (r2CLoginGame.Error != ErrorCode.ERR_Success)//如果Realm网关负载驱动服务器登录失败，则返回错误码
            {
                response.Error = r2CLoginGame.Error;
                return;
            }

            //通过Router节点服务器建立和Gate网关负载驱动服务器连接
            // 创建一个gate Session,并且保存到SessionComponent中
            Session gateSession = await netComponent.CreateRouterSession(NetworkHelper.ToIPEndPoint(r2CLoginGame.Address), account, password);
            gateSession.AddComponent<ClientSessionErrorComponent>();
            root.AddComponent<SessionComponent>().Session = gateSession;
            //请求登录Gate网关服务器
            G2C_LoginGameGate g2CLoginGate = (G2C_LoginGameGate)await gateSession.Call(new C2G_LoginGameGate() { Key = r2CLoginGame.Key, GateId = r2CLoginGame.GateId });

            Log.Debug("登陆gate成功!");

            response.PlayerId = g2CLoginGate.PlayerId;
    }
}