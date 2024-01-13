namespace ET.Client
{
    [MessageHandler(SceneType.All)]
    public class NetClient2Main_SessionDisposeHandler: MessageHandler<Scene, NetClient2Main_SessionDispose>
    {
        protected override async ETTask Run(Scene entity, NetClient2Main_SessionDispose message)
        {
            if (message.Error < 400000)//小于400000时才报错
            {
                Log.Error($"session dispose, error: {message.Error}");
            }
            
            await ETTask.CompletedTask;
        }
    }
}