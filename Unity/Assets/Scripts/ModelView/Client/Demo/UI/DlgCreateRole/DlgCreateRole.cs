namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCreateRole :Entity,IAwake,IUILogic,IUpdate
	{

		public DlgCreateRoleViewComponent View { get => this.GetComponent<DlgCreateRoleViewComponent>();} 

		 

	}
}
