namespace ET.Client;

/// <summary>
/// 错误弹窗事件
/// </summary>
[Event(SceneType.ProjectS)]
public class CreateErrorWindowHandler: AEvent<Scene, CreateErrorWindow>
{
    protected override async ETTask Run(Scene root, CreateErrorWindow a)
    {
        UIComponent uiComponent = root.GetComponent<UIComponent>();
        uiComponent.ShowWindow(WindowID.WindowID_ErrorWindow);//显示错误弹窗
        uiComponent.GetDlgLogic<DlgErrorWindow>().ShowErrorContent(a.ErrorCode);//显示错误内容
        await ETTask.CompletedTask;
    }
}