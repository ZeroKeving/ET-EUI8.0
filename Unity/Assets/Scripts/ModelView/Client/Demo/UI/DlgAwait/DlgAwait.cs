namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgAwait :Entity,IAwake,IUILogic
	{

		public DlgAwaitViewComponent View { get => this.GetComponent<DlgAwaitViewComponent>();}

		public bool isNeedAwait { get; set; }//是否需要等待（0.5秒内就有反馈的操作不需要）

	}
}
