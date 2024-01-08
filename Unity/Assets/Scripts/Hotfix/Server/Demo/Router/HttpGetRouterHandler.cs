using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ET.Server
{
    /// <summary>
    /// 通过Http获取路由节点
    /// </summary>
    [HttpHandler(SceneType.RouterManager, "/get_router")]
    public class HttpGetRouterHandler : IHttpHandler
    {
        public async ETTask Handle(Scene scene, HttpListenerContext context)
        {
            HttpGetRouterResponse response = new();
            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Realms)//遍历起服配置
            {
                response.Realms.Add(startSceneConfig.InnerIPPort.ToString());
            }
            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Routers)//遍历起服配置
            {
                response.Routers.Add($"{startSceneConfig.StartProcessConfig.OuterIP}:{startSceneConfig.Port}");
            }
            HttpHelper.Response(context, response);//回复客户端
            await ETTask.CompletedTask;
        }
    }
}
