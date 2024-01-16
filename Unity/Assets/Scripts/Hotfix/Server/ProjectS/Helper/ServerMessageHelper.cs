namespace ET.Server;

/// <summary>
/// 服务器消息助手类
/// </summary>
public static class ServerMessageHelper
{
    /// <summary>
    /// 向对应场景发起通讯
    /// </summary>
    /// <param name="root"></param>
    /// <param name="zone">区服id</param>
    /// <param name="sceneName">场景类型</param>
    /// <param name="iRequest">消息协议</param>
    /// <returns></returns>
    public static async ETTask<IResponse> CallActor(Scene root,int zone, string sceneName, IRequest iRequest)
    {
        ActorId actorId = StartSceneConfigCategory.Instance.GetSceneActorId(zone,sceneName);//获取该场景的通讯Id

        return await root.GetComponent<MessageSender>().Call(actorId, iRequest);
    }
}