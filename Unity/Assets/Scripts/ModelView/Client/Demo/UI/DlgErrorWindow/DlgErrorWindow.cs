namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgErrorWindow :Entity,IAwake,IUILogic
	{

		public DlgErrorWindowViewComponent View { get => this.GetComponent<DlgErrorWindowViewComponent>();} 

		 

	}
}
