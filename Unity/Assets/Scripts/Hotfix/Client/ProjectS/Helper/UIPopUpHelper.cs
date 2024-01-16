namespace ET.Client;

/// <summary>
/// UI弹窗助手类
/// </summary>
public static class UIPopUpHelper
{
    /// <summary>
    /// 创建一个错误信息弹窗
    /// </summary>
    /// <param name="root"></param>
    /// <param name="errorCode"></param>
    public static void CreatePopUpWindow(Scene root,int errorCode)
    {
        EventSystem.Instance.PublishAsync(root, new CreatePopUpWindow(){ ErrorCode = errorCode}).Coroutine();//用协程的方式发布错误信息弹窗事件
    }
}