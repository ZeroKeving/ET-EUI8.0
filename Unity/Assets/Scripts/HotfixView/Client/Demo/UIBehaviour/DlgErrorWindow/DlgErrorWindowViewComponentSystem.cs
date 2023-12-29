
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgErrorWindowViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgErrorWindowViewComponent))]
	public static partial class DlgErrorWindowViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgErrorWindowViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgErrorWindowViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
