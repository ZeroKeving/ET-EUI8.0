namespace ET.Server;

/// <summary>
/// Realm服务器向Gate网关服务器发送获取登录游戏令牌消息处理(MessageHandler是交给实体进行业务处理，这个Scene是可以自定义为其他实体)
/// </summary>
[MessageHandler(SceneType.Gate)]
[FriendOf(typeof(GateUserMgrComponent))]
public class R2G_GetLoginGameKeyHandler : MessageHandler<Scene, R2G_GetLoginGameKey, G2R_GetLoginGameKey>
{
    protected override async ETTask Run(Scene scene, R2G_GetLoginGameKey request, G2R_GetLoginGameKey response)
    {
        GateUserMgrComponent gateUserMgrComponent = scene.GetComponent<GateUserMgrComponent>();//获取Gate用户经理组件

        gateUserMgrComponent.Users.TryGetValue(request.Info.Account, out GateUser gateUser);//获取该账号的Gate用户
        if (gateUser != null)//如果能获取到用户，说明有其他客户端使用同样的账号登录
        {
            //TO DO 执行下线顶号逻辑
        }

        GateSessionKeyComponent gateSessionKeyComponent = scene.GetComponent<GateSessionKeyComponent>();
        
        long key = RandomGenerator.RandInt64();//随机生成一个令牌
        
        gateSessionKeyComponent.Add(key, request.Info);//在Gate网关钥匙组件上添加该账号,等待20秒后移除该账号的登录钥匙
        response.Key = key;
        response.GateId = scene.Id;
        await ETTask.CompletedTask;
    }
}