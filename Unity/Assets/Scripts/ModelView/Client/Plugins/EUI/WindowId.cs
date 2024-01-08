namespace ET.Client
{
    public enum WindowID
    {
        WindowID_Invaild = 0,
        WindowID_MessageBox,
        WindowID_Lobby,    //房间界面
        WindowID_Login,     //登录界面
        WindowID_RedDot,   //红点测试界面
        WindowID_Helper,   //提示界面
    	WindowID_LSLobby,
		WindowID_LSLogin,
		WindowID_LSRoom,
		WindowID_InitialInterface,//初始化界面
		WindowID_LoginUI,//登录界面
		WindowID_Await,//加载等待弹窗
		WindowID_LoadResourceAndLogin,//加载资源界面
		WindowID_StartGameUI,//开始游戏界面
		WindowID_ErrorWindow,
		WindowID_SetUI,
	}
}