using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	/// <summary>
	/// 设置界面
	/// </summary>
	[FriendOf(typeof(MultilingualComponent))]
	[FriendOf(typeof(DlgSetUI))]
	public static  class DlgSetUISystem
	{

		public static void RegisterUIEvent(this DlgSetUI self)
		{
			self.RegisterCloseEvent<DlgSetUI>(self.View.E_CloseButtonButton);//关闭按钮注册关闭事件
			self.View.E_CNButtonButton.AddListener(self.OnCNButtonClickHandler); //切换中文按钮监听
			self.View.E_ENButtonButton.AddListener(self.OnENButtonClickHandler); //切换中文按钮监听
		}

		public static void ShowWindow(this DlgSetUI self, Entity contextData = null)
		{
			self.Refresh();//刷新界面
		}

		/// <summary>
		/// 切换中文
		/// </summary>
		/// <param name="self"></param>
		public static void OnCNButtonClickHandler(this DlgSetUI self)
		{
			self.Root().GetComponent<MultilingualComponent>().ChangeMultilingualType(1);
			self.Refresh();//刷新界面
		}
		
		/// <summary>
		/// 切换英文
		/// </summary>
		/// <param name="self"></param>
		public static void OnENButtonClickHandler(this DlgSetUI self)
		{
			self.Root().GetComponent<MultilingualComponent>().ChangeMultilingualType(2);
			self.Refresh();//刷新界面
		}

		/// <summary>
		/// 刷新界面
		/// </summary>
		/// <param name="self"></param>
		public static void Refresh(this DlgSetUI self)
		{
			switch (self.Root().GetComponent<MultilingualComponent>().CurrentMultilingualType)
			{
				case MultilingualType.CN:
					self.View.E_CNButtonButton.Select();//显示为被选择状态
					break;
				case MultilingualType.EN:
					self.View.E_ENButtonButton.Select();//显示为被选择状态
					break;
				default:
					return;
			}
			
			self.View.E_LanguageTextTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[3]);//显示切换语言提示
		}

	}
}
