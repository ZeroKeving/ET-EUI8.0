using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgStartGameUI :Entity,IAwake,IUILogic
	{

		public DlgStartGameUIViewComponent View { get => this.GetComponent<DlgStartGameUIViewComponent>();}

		public Dictionary<int, Scroll_Item_server> scrollItemServersDict;//游戏区服列表
		public bool IsLogin = false;//是否是登录状态

	}
}
