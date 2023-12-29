using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgStartGameUI))]
	public static  class DlgStartGameUISystem
	{

		public static void RegisterUIEvent(this DlgStartGameUI self)
		{
			self.View.E_StartGameButtonButton.AddListener(self.OnStartGameClickHandler);// 开始游戏按钮监听
		 
		}

		public static void ShowWindow(this DlgStartGameUI self, Entity contextData = null)
		{
			//本地读取服务器地址的方法
			string[] lines = File.ReadAllLines(@"..\Unity\Assets\Config\Excel\ServerAddress.txt");//获取服务器地址列表
			self.View.E_ServerInfoListDropdown.options.Clear();//清空显示列表
			
			foreach (var address in lines)//将服务器地址列表数据显示出来
			{
				Dropdown.OptionData optionData = new Dropdown.OptionData();
				optionData.text = address;
				self.View.E_ServerInfoListDropdown.options.Add(optionData);
			}
		}

		/// <summary>
		/// 开始游戏按钮处理
		/// </summary>
		public static void OnStartGameClickHandler(this DlgStartGameUI self)
		{
			// 打开登录页面,并传入地址信息
			self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_LoginUI); 
		}

	}
}
