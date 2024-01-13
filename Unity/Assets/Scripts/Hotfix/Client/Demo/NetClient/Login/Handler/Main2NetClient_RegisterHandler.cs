using System.Net;
using System.Net.Sockets;

namespace ET.Client;

/// <summary>
/// Main纤程与NetClient纤程通讯的注册消息处理
/// </summary>
[MessageHandler(SceneType.NetClient)]
public class Main2NetClient_RegisterHandler: MessageHandler<Scene, Main2NetClient_Register, NetClient2Main_Register>
{
    protected override async ETTask Run(Scene root, Main2NetClient_Register request, NetClient2Main_Register response)
    {
        string account = request.Account;
        string password1 = request.Password1;
        string password2 = request.Password2;
        // 创建一个ETModel层的Session
        root.RemoveComponent<RouterAddressComponent>(); //移除路由节点地址组件，保证每次注册获取新的路由节点地址

        // 获取路由跟realm服务器地址
        RouterAddressComponent routerAddressComponent =
                root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort); //设定软路由服务器的地址和端口
        await routerAddressComponent.Init(); //请求RouterMananger服务器，来获取一系列的路由节点地址

        
        //移除老的网络组件，保证每次注册获取网络会话组件
        if(root.GetComponent<NetComponent>() != null)
        {
            SessionComponent oldSessionComponent = root.GetComponent<SessionComponent>();
            if (oldSessionComponent != null)
            {
                oldSessionComponent.Session.Error = ErrorCode.Inform_NewSession;//新建连接告知
                root.RemoveComponent<SessionComponent>();
            }
            root.RemoveComponent<NetComponent>(); //移除网络组件，保证每次注册获取新的网络组件
        }
        
        //给NetClient添加网络组件
        root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily,
            NetworkProtocol.UDP);
        //把记录MainFiberId记录在纤程父对象组件
        root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

        NetComponent netComponent = root.GetComponent<NetComponent>();

        //根据账号取模来获取Realm网关负载均衡服务器地址（为什么用账号取模？如果有两个玩家同时注册账号，用的账号一致，就可以使账号连接同一个服务器，来保证唯一性）
        IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

        //通过Router节点服务器建立和Realm网关负载驱动服务器连接
        R2C_Register r2CRegister;
        using (Session session = await netComponent.CreateRouterSession(realmAddress, account, password1))
        {
            r2CRegister = (R2C_Register)await session.Call(new C2R_Register()
            {
                Account = account, Password1 = password1, Password2 = password2
            }); //使用账号密码注册
        }

        if (r2CRegister.Error != ErrorCode.ERR_Success) //如果Realm网关负载驱动服务器登录失败，则返回错误码
        {
            response.Error = r2CRegister.Error;
            return;
        }

        Log.Debug("注册账号成功!");
    }
}