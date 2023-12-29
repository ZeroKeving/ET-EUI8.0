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
    public static void CreateErrorWindow(Scene root,int errorCode)
    {
        EventSystem.Instance.PublishAsync(root, new CreateErrorWindow(){ ErrorCode = errorCode}).Coroutine();//用协程的方式发布错误信息弹窗事件
    }

    /// <summary>
    /// 创建一个提示信息弹窗
    /// </summary>
    /// <param name="root"></param>
    /// <param name="hintCode"></param>
    public static void CreateHintWindow(Scene root,int hintCode)
    {
        EventSystem.Instance.PublishAsync(root, new CreateHintWindow(){HintCode = hintCode}).Coroutine();//用协程的方式发布提示信息弹窗事件
        //TO DO：完善提示信息弹窗
    }
}