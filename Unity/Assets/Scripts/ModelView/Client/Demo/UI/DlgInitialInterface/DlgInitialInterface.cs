namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgInitialInterface :Entity,IAwake,IUILogic
	{

		public DlgInitialInterfaceViewComponent View { get => this.GetComponent<DlgInitialInterfaceViewComponent>();} 

		 

	}
}
