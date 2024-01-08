
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSetUIViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSetUIViewComponent))]
	public static partial class DlgSetUIViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSetUIViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSetUIViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
