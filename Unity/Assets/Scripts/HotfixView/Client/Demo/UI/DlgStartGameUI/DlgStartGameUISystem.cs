﻿using System.Collections;
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
    [FriendOf(typeof(DlgStartGameUI))]
    [FriendOf(typeof(ServerInfosComponent))]
    [FriendOf(typeof(ServerInfo))]
    public static class DlgStartGameUISystem
    {
        public static void RegisterUIEvent(this DlgStartGameUI self)
        {
            self.View.E_StartGameButtonButton.AddListenerAsync(() => { return self.OnStartGameClickHandler();},self.Root()); //开始游戏按钮监听
            self.View.E_AccountButtonButton.AddListener(self.OnAccountButtonClickHandler); //切换账号按钮监听
            self.View.E_SetButtonButton.AddListener(self.OnSetButtonClickHandler); //设置按钮监听
            self.View.E_ServerInfoButton.AddListener(self.OnServerInfoClickHandler); //区服按钮监听
            self.View.E_SeverListCloseButtonButton.AddListener(self.OnSeverListCloseClickHandler); //关闭区服选择界面按钮监听
            self.View.ELoopScrollList_ServerInfoLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnLoopScrollListItemRefeshHandler(transform, index);
            }); //注册服务器循环列表项监听
        }

        public static void ShowWindow(this DlgStartGameUI self, Entity contextData = null)
        {
            self.Refresh(); //刷新界面
            EUIHelper.UIAwaitsyncAction(self, () => { return self.AutoLogin(); }).Coroutine(); //自动登录游戏
        }

        /// <summary>
        /// 隐藏窗口时调用
        /// </summary>
        /// <param name="self"></param>
        public static void HideWindow(this DlgStartGameUI self)
        {
            self.RemoveUIScrollItems(ref self.scrollItemServersDict);//为了节省资源在窗口被隐藏时，把滑动列表项释放
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
        public static async ETTask OnStartGameClickHandler(this DlgStartGameUI self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            if (self.IsLogin) //如果登录成功
            {
                try
                {
                    //进入游戏
                    int errorCode = await LoginHelper.EnterGame(self.Root(),PlayerPrefs.GetString("Account"), PlayerPrefs.GetString("Password"));

                    if (errorCode != ErrorCode.ERR_Success) //如果获取的不是一个成功的错误码
                    {
                        UIPopUpHelper.CreateErrorWindow(self.Root(), errorCode); //创建错误弹窗
                        
                        uiComponent.GetDlgLogic<DlgStartGameUI>().IsLogin = false; //设置为未登录状态
                        uiComponent.GetDlgLogic<DlgStartGameUI>().Refresh(); //刷新开始界面
                        return;
                    }

                    uiComponent.ShowWindow(WindowID.WindowID_InitialInterface); //显示游戏初始界面
                    uiComponent.CloseWindow(WindowID.WindowID_StartGameUI); //关闭游戏开始界面
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
                
            }
            else
            {
                //打开登录页面
                uiComponent.ShowWindow(WindowID.WindowID_LoginUI);
            }

            await ETTask.CompletedTask;
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
            self.View.ELoopScrollList_ServerInfoLoopVerticalScrollRect.RefreshCells();//刷新列表项
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
            ServerInfosComponent serverInfosComponent = self.Root().GetComponent<ServerInfosComponent>();//获取区服信息
            self.View.E_ServerInfoTextTextMeshProUGUI.SetText(serverInfosComponent.ServerInfosList[serverInfosComponent.CurrentServerIndex].ServerName);//显示选中区服名称
            self.View.E_ServerStatusImage.color = serverInfosComponent.ServerInfosList[serverInfosComponent.CurrentServerIndex].Status == (int)ServerStatus.Active? Color.green : Color.gray;//对该区服的状态设置颜色
            
            //显示游戏区服滑动列表项
            int count = self.Root().GetComponent<ServerInfosComponent>().ServerInfosList.Count;//获取游戏区服信息
            self.AddUIScrollItems(ref self.scrollItemServersDict,count);//添加滑动列表项
            self.View.ELoopScrollList_ServerInfoLoopVerticalScrollRect.SetVisible(true,count);//将其显示出来
        }

        /// <summary>
        /// 游戏区服滑动列表项刷新处理
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="index"></param>
        public static void OnLoopScrollListItemRefeshHandler(this DlgStartGameUI self, Transform transform, int index)
        {
            Scroll_Item_server scrollItemServer = self.scrollItemServersDict[index].BindTrans(transform);//先获取UI列表项的逻辑实体，然后在绑定UI的位置
            ServerInfosComponent serverInfosComponent = self.Root().GetComponent<ServerInfosComponent>();//获取游戏区服信息组件

            if (serverInfosComponent.CurrentServerIndex == index)//显示区服选中
            {
                scrollItemServer.E_ServerButtonButton.Select();
            }
            
            scrollItemServer.E_ServerTextTextMeshProUGUI.SetText(serverInfosComponent.ServerInfosList[index].ServerName);//显示区服名称
            scrollItemServer.E_ServerStatusImage.color = serverInfosComponent.ServerInfosList[index].Status == (int)ServerStatus.Active? Color.green : Color.gray;//对该区服的状态设置颜色
            
            scrollItemServer.E_ServerButtonButton.AddListenerWithId(self.OnSelectSeverInfoHandler,index);//游戏区服按钮有参数的监听
        }

        /// <summary>
        /// 选择区服按键处理
        /// </summary>
        /// <param name="self"></param>
        public static void OnSelectSeverInfoHandler(this DlgStartGameUI self,int Index)
        {
            self.Root().GetComponent<ServerInfosComponent>().CurrentServerIndex = Index;//设置当前选中区服
            self.View.ELoopScrollList_ServerInfoLoopVerticalScrollRect.RefreshCells();//刷新列表项
        }

        
    }
}