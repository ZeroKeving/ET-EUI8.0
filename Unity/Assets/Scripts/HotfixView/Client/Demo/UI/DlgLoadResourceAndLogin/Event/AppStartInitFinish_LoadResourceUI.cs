namespace ET.Client;

/// <summary>
/// app启动初始化完成_创建登录UI
/// </summary>
[Event(SceneType.ProjectS)]
public class AppStartInitFinish_LoadResourceUI: AEvent<Scene, AppStartInitFinish>
{
    protected override async ETTask Run(Scene root, AppStartInitFinish a)
    {
        ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();//创建客户端通讯组件
        await clientSenderCompnent.CreatNetClientFiber();
        
        //打开登录界面
        await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_LoadResourceAndLogin);
    }
}