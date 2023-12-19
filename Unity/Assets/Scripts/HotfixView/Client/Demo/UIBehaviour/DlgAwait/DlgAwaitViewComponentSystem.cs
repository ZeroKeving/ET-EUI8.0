
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgAwaitViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgAwaitViewComponent))]
	public static partial class DlgAwaitViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgAwaitViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgAwaitViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
