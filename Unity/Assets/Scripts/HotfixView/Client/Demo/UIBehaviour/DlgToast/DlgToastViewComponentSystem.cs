
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgToastViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgToastViewComponent))]
	public static partial class DlgToastViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgToastViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgToastViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
