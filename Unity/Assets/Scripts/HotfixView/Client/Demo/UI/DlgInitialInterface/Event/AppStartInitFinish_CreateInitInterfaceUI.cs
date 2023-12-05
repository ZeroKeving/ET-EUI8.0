namespace ET.Client;

/// <summary>
/// app启动初始化完成_创建登录UI
/// </summary>
[Event(SceneType.ProjectS)]
public class AppStartInitFinish_CreateInitInterfaceUI: AEvent<Scene, AppStartInitFinish>
{
    protected override async ETTask Run(Scene root, AppStartInitFinish a)
    {
        await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_InitialInterface);
    }
}