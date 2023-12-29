
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgStartGameUIViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgStartGameUIViewComponent))]
	public static partial class DlgStartGameUIViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgStartGameUIViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgStartGameUIViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
