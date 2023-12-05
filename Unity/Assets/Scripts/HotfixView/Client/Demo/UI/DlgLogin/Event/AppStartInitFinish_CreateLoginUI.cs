namespace ET.Client
{
    /// <summary>
    /// app启动初始化完成_创建登录UI
    /// </summary>
    [Event(SceneType.Demo)]
    public class AppStartInitFinish_CreateLoginUI: AEvent<Scene, AppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, AppStartInitFinish args)
        {
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);

        }
    }
}