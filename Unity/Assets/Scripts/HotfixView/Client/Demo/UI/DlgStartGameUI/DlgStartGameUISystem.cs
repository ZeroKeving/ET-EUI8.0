using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 游戏开始界面
    /// </summary>
    [FriendOf(typeof (DlgStartGameUI))]
    public static class DlgStartGameUISystem
    {
        public static void RegisterUIEvent(this DlgStartGameUI self)
        {
            self.View.E_StartGameButtonButton.AddListener(self.OnStartGameClickHandler); //开始游戏按钮监听
            self.View.E_AccountButtonButton.AddListener(self.OnAccountButtonClickHandler); //切换账号按钮监听
            self.View.E_SetButtonButton.AddListener(self.OnSetButtonClickHandler); //设置按钮监听
            self.View.E_ServerInfoButton.AddListener(self.OnServerInfoClickHandler); //区服按钮监听
            self.View.E_SeverListCloseButtonButton.AddListener(self.OnSeverListCloseClickHandler);//关闭区服选择界面按钮监听
        }

        public static void ShowWindow(this DlgStartGameUI self, Entity contextData = null)
        {
            self.Refresh(); //刷新界面
            EUIHelper.UIAwaitsyncAction(self, () => { return self.AutoLogin(); }).Coroutine(); //自动登录游戏
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        public static void Refresh(this DlgStartGameUI self)
        {
            if (self.IsLogin) //是否是登录状态
            {
                self.ShowLogin(); //显示登录状态
            }
            else
            {
                self.ShowNotLogin(); //显示未登录状态
            }
        }

        /// <summary>
        /// 开始游戏按钮处理
        /// </summary>
        public static void OnStartGameClickHandler(this DlgStartGameUI self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            if (self.IsLogin) //如果登录成功
            {
                uiComponent.ShowWindow(WindowID.WindowID_InitialInterface); //显示游戏初始界面
                uiComponent.CloseWindow(WindowID.WindowID_StartGameUI); //关闭游戏开始界面
            }
            else
            {
                //打开登录页面
                self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_LoginUI);
            }
        }

        /// <summary>
        /// 切换账号按钮处理
        /// </summary>
        /// <param name="self"></param>
        public static void OnAccountButtonClickHandler(this DlgStartGameUI self)
        {
            //打开登录页面
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_LoginUI);
        }

        /// <summary>
        /// 打开设置界面
        /// </summary>
        /// <param name="self"></param>
        public static void OnSetButtonClickHandler(this DlgStartGameUI self)
        {
            //打开设置界面
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SetUI);
        }

        /// <summary>
        /// 开启区服选择列表界面按钮处理
        /// </summary>
        /// <param name="self"></param>
        public static void OnServerInfoClickHandler(this DlgStartGameUI self)
        {
            self.View.EG_SeverListPanelRectTransform.SetVisible(true);
        }
        
        /// <summary>
        /// 关闭区服选择列表界面按钮处理
        /// </summary>
        /// <param name="self"></param>
        public static void OnSeverListCloseClickHandler(this DlgStartGameUI self)
        {
            self.View.EG_SeverListPanelRectTransform.SetVisible(false);
        }

        /// <summary>
        /// 自动登录
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask AutoLogin(this DlgStartGameUI self)
        {
            if ((PlayerPrefs.GetString("Account") != string.Empty) && (PlayerPrefs.GetString("Password") != string.Empty)) //如果本地存的账号和密码不为空则自动登录
            {
                try
                {
                    int errorCode =
                            await LoginHelper.LoginGame(self.Root(), PlayerPrefs.GetString("Account"), PlayerPrefs.GetString("Password")); //登录游戏

                    if (errorCode != ErrorCode.ERR_Success) //如果获取的不是一个成功的错误码
                    {
                        return;
                    }

                    self.IsLogin = true;
                    self.Refresh(); //刷新界面
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }
            else
            {
                self.IsLogin = false;
                self.Refresh(); //刷新界面
            }
        }

        /// <summary>
        /// 显示未登录状态
        /// </summary>
        /// <param name="self"></param>
        public static void ShowNotLogin(this DlgStartGameUI self)
        {
            self.View.E_AccountButtonButton.SetVisible(false); //隐藏账号切换列表
            self.View.E_ServerInfoButton.SetVisible(false); //隐藏区服选择列表
            self.View.EG_SeverListPanelRectTransform.SetVisible(false); //隐藏区服显示列表
            self.View.E_StartGameTextTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1]); //显示为登录游戏
        }

        /// <summary>
        /// 显示为登录状态
        /// </summary>
        /// <param name="self"></param>
        public static void ShowLogin(this DlgStartGameUI self)
        {
            self.View.E_AccountButtonButton.SetVisible(true); //显示账号切换列表
            self.View.E_ServerInfoButton.SetVisible(true); //显示区服选择列表
            self.View.EG_SeverListPanelRectTransform.SetVisible(false); //隐藏区服显示列表
            self.View.E_StartGameTextTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[2]); //显示为开始游戏
        }

        
    }
}