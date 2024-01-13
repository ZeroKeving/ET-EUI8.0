using System;
using System.Collections.Generic;
using System.IO;

namespace ET.Client
{
    /// <summary>
    /// 初始化客户端进入事件
    /// </summary>
    [Event(SceneType.Main)]
    public class EntryEvent3_InitClient: AEvent<Scene, EntryEvent3>
    {
        protected override async ETTask Run(Scene root, EntryEvent3 args)
        {
            GlobalComponent globalComponent = root.AddComponent<GlobalComponent>();
            root.AddComponent<UIPathComponent>();
            root.AddComponent<UIEventComponent>();
            root.AddComponent<UIComponent>();
            root.AddComponent<ResourcesLoaderComponent>();
            root.AddComponent<PlayerComponent>();
            root.AddComponent<CurrentScenesComponent>();
            
            
            root.AddComponent<MultilingualComponent>();//添加多语言组件
            root.AddComponent<ServerInfosComponent>();//添加游戏区服信息组件
            
            // 根据配置修改掉Main Fiber的SceneType
            SceneType sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
            root.SceneType = sceneType;
            
            
            await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
        }
    }
}