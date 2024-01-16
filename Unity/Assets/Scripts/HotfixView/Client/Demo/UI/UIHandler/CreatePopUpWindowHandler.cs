namespace ET.Client;

/// <summary>
/// 错误弹窗事件
/// </summary>
[Event(SceneType.ProjectS)]
public class CreatePopUpWindowHandler: AEvent<Scene, CreatePopUpWindow>
{
    protected override async ETTask Run(Scene root, CreatePopUpWindow a)
    {
        UIComponent uiComponent = root.GetComponent<UIComponent>(); // 获得uiComponet
        int type = HintMultilingualConfigCategory.Instance.Type[a.ErrorCode]; // 获取错误类型对应的弹窗类型 0=强提醒 1=中提醒 2=弱提醒

        switch (type)
        {
            case 0: // 强提醒
                uiComponent.ShowWindow(WindowID.WindowID_StrongPopUpWindow);//显示强提醒弹窗
                uiComponent.GetDlgLogic<DlgStrongPopUpWindow>().ShowContent(a.ErrorCode);//显示错误内容
                break;
            case 1: // 中提醒
                uiComponent.ShowWindow(WindowID.WindowID_StrongPopUpWindow);//Todo显示强提醒弹窗
                uiComponent.GetDlgLogic<DlgStrongPopUpWindow>().ShowContent(a.ErrorCode);//Todo显示强提醒弹窗
                break;
            case 2: // 弱提醒 Toast
                uiComponent.ShowWindow(WindowID.WindowID_Toast);//Todo显示强提醒弹窗
                uiComponent.GetDlgLogic<DlgToast>().ShowContent(a.ErrorCode);//Todo显示强提醒弹窗
                break;
            default:
                break;
        }
        await ETTask.CompletedTask;
    }
}