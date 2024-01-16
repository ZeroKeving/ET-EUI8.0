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
    /// 创建一个ui弹窗事件
    /// </summary>
    public struct CreatePopUpWindow
    {
        public int ErrorCode;
    }
    
    
    /// <summary>
    /// 登录游戏完成
    /// </summary>
    public struct LoginGameFinish
    {
    }
}