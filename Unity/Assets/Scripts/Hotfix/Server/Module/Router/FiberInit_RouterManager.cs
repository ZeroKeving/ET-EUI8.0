using System.Net;

namespace ET.Server
{
    /// <summary>
    /// 路由管理服务器纤程初始化
    /// </summary>
    [Invoke((long)SceneType.RouterManager)]
    public class FiberInit_RouterManager: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get((int)root.Id);
            root.AddComponent<HttpComponent, string>($"http://*:{startSceneConfig.Port}/");//添加网络组件，获得处理http网络请求的能力

            await ETTask.CompletedTask;
        }
    }
}