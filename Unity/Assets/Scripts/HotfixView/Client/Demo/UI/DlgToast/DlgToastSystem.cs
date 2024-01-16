using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgToast))]
	public static  class DlgToastSystem
	{

		public static void RegisterUIEvent(this DlgToast self)
		{
		 
		}

		public static void ShowWindow(this DlgToast self, Entity contextData = null)
		{
		}
		
		/// <summary>
		/// 显示错误内容
		/// </summary>
		/// <param name="self"></param>
		/// <param name="errorCode"></param>
		public static void ShowContent(this DlgToast self, int errorCode)
		{
			string title = HintMultilingualConfigCategory.Instance.Title[errorCode]; // 获取标题
			self.View.E_TitleTextMeshProUGUI.SetText(title); // 设置标题
			self.DelayHide().Coroutine();
		}

		
		/// <summary>
		/// 延时消失
		/// </summary>
		/// <param name="self"></param>
		public static async ETTask DelayHide(this DlgToast self)
		{
			await self.Scene().GetComponent<TimerComponent>().WaitAsync(2000);// 等待2s
			self.Scene().GetComponent<UIComponent>().CloseWindow(self.GetParent<UIBaseWindow>().WindowID); // 关闭弹窗
		}

		 

	}
}
