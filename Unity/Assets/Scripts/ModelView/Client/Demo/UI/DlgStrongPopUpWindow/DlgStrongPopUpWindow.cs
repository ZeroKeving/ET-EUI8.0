namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgStrongPopUpWindow :Entity,IAwake,IUILogic
	{

		public DlgStrongPopUpWindowViewComponent View { get => this.GetComponent<DlgStrongPopUpWindowViewComponent>();} 

		 

	}
}
