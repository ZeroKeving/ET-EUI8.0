
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_server))]
	public static partial class Scroll_Item_serverSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_server self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_server self )
		{
			self.DestroyWidget();
		}
	}
}
