namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgStartGameUI :Entity,IAwake,IUILogic
	{

		public DlgStartGameUIViewComponent View { get => this.GetComponent<DlgStartGameUIViewComponent>();} 

		 

	}
}
