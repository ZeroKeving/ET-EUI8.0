namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgLoginUI :Entity,IAwake,IUILogic,IUpdate
	{

		public DlgLoginUIViewComponent View { get => this.GetComponent<DlgLoginUIViewComponent>();} 

		 

	}
}
