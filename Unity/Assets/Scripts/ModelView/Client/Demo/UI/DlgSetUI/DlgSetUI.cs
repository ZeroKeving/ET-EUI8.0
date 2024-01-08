namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSetUI :Entity,IAwake,IUILogic
	{

		public DlgSetUIViewComponent View { get => this.GetComponent<DlgSetUIViewComponent>();} 

		 

	}
}
