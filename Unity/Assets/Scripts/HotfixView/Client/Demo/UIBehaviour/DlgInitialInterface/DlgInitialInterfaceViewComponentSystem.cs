
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgInitialInterfaceViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgInitialInterfaceViewComponent))]
	public static partial class DlgInitialInterfaceViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgInitialInterfaceViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgInitialInterfaceViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
