
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgStrongPopUpWindowViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgStrongPopUpWindowViewComponent))]
	public static partial class DlgStrongPopUpWindowViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgStrongPopUpWindowViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgStrongPopUpWindowViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
