
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgLoadResourceAndLoginViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgLoadResourceAndLoginViewComponent))]
	public static partial class DlgLoadResourceAndLoginViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgLoadResourceAndLoginViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgLoadResourceAndLoginViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
