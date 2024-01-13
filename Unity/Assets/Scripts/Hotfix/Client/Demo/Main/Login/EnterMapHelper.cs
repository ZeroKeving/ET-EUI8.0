using System;


namespace ET.Client
{
    /// <summary>
    /// 进入地图帮助类
    /// </summary>
    public static partial class EnterMapHelper
    {
        /// <summary>
        /// 进入地图
        /// </summary>
        /// <param name="root"></param>
        public static async ETTask EnterMapAsync(Scene root)
        {
            try
            {
                //客户端发向Gate网关服务器，进入地图
                G2C_EnterMap g2CEnterMap = await root.GetComponent<ClientSenderCompnent>().Call(new C2G_EnterMap()) as G2C_EnterMap;
                
                // 等待场景切换完成
                await root.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();
                
                EventSystem.Instance.Publish(root, new EnterMapFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }	
        }
        
        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="fiber"></param>
        public static async ETTask Match(Fiber fiber)
        {
            try
            {
                G2C_Match g2CEnterMap = await fiber.Root.GetComponent<ClientSenderCompnent>().Call(new C2G_Match()) as G2C_Match;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }	
        }
    }
}