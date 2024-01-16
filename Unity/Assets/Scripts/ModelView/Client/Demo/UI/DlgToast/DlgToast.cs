namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgToast :Entity,IAwake,IUILogic
	{

		public DlgToastViewComponent View { get => this.GetComponent<DlgToastViewComponent>();} 

		 

	}
}
