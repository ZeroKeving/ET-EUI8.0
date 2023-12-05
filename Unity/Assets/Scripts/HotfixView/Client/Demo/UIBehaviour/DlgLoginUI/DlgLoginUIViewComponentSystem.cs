
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgLoginUIViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgLoginUIViewComponent))]
	public static partial class DlgLoginUIViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgLoginUIViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgLoginUIViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
