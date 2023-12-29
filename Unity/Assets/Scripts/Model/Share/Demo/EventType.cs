namespace ET.Client
{
    public struct SceneChangeStart
    {
    }
    
    public struct SceneChangeFinish
    {
    }
    
    public struct AfterCreateClientScene
    {
    }
    
    public struct AfterCreateCurrentScene
    {
    }

    /// <summary>
    /// App初始化完成
    /// </summary>
    public struct AppStartInitFinish
    {
    }

    public struct LoginFinish
    {
    }

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    /// <summary>
    /// 创建一个错误信息弹窗事件
    /// </summary>
    public struct CreateErrorWindow
    {
        public int ErrorCode;
    }
    
    /// <summary>
    /// 创建一个提示信息弹窗事件
    /// </summary>
    public struct CreateHintWindow
    {
        public int HintCode;
    }
    
    /// <summary>
    /// 登录游戏完成
    /// </summary>
    public struct LoginGameFinish
    {
    }
}