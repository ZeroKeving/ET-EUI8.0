﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 登录UI界面
    /// </summary>
    [FriendOf(typeof (DlgLoginUI))]
    [FriendOf(typeof (DlgStartGameUI))]
    [EntitySystemOf(typeof (DlgLoginUI))]
    public static partial class DlgLoginUISystem
    {
        /// <summary>
        /// 登记UI事件
        /// </summary>
        /// <param name="self"></param>
        public static void RegisterUIEvent(this DlgLoginUI self)
        {
            self.RegisterCloseEvent<DlgLoginUI>(self.View.E_LoginCloseButtonButton); //关闭按钮注册关闭事件
            self.RegisterCloseEvent<DlgLoginUI>(self.View.E_RegisterCloseButtonButton); //关闭按钮注册关闭事件
            self.View.E_CutRegisterButtonButton.AddListener(self.OnCutRegisterClickHandler); //切换注册按钮监听
            self.View.E_CutLoginButtonButton.AddListener(self.OnCutLoginClickHandler); //切换登录按钮监听
            self.View.E_StartRegisterButtonButton.AddListenerAsync(() => { return self.OnStartRegisterClickHandler(); }, self.Root()); //异步监听注册按键
            self.View.E_LoginButtonButton.AddListenerAsync(() => { return self.OnLoginClickHandler(); }, self.Root()); //异步监听登录按键
        }

        public static void ShowWindow(this DlgLoginUI self, Entity contextData = null)
        {
            //从本地获取默认登录账号信息
            self.View.E_LoginUserTMP_InputField.text = PlayerPrefs.GetString("Account", string.Empty);
            self.View.E_LoginPasswordTMP_InputField.text = PlayerPrefs.GetString("Password", string.Empty);
            
            self.Refresh();
            self.View.EG_LoginPanelRectTransform.SetVisible(true); // 显示登录页面
            self.View.EG_RegisterRectTransform.SetVisible(false); //隐藏注册界面
        }

        /// <summary>
        /// 界面刷新
        /// </summary>
        public static void Refresh(this DlgLoginUI self)
        {
            //显示文本内容
            // 登录
            self.View.E_LoginTextTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1000010]);
            self.View.E_CutRegisterButtonTextTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1000005]);
            // 注册
            self.View.E_RegisterAccountPlaceholderTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1000009]);
            self.View.E_RegisterPasswordPlaceholderTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1000007]);
            self.View.E_RegisterPasswordPlaceholder2TextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1000008]);
            self.View.E_StartRegisterButtonTextTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1000004]);
            self.View.E_BackLoginButtonTextTextMeshProUGUI.SetText(UIMultilingualConfigCategory.Instance.TextDict[1000011]);
            
        }

        [EntitySystem]
        private static void Awake(this ET.Client.DlgLoginUI self)
        {
        }

        [EntitySystem]
        private static void Update(this ET.Client.DlgLoginUI self)
        {
            // 判断用户账号密码格式是否输入正确
            if (!Regex.IsMatch(self.View.E_LoginUserTMP_InputField.text.Trim(), @"^(?=.*[0-9A-Za-z].*).{6,15}$") ||
                !Regex.IsMatch(self.View.E_LoginPasswordTMP_InputField.text.Trim(), @"^(?=.*[0-9A-Za-z].*).{6,15}$")) //判断密码是否为6到15位合法字符组成
            {
                self.View.E_LoginButtonButton.interactable = false;
                self.View.E_LoginTextTextMeshProUGUI.color = new Color(1, 246f / 255f, 229f / 255f, 76f / 255f);
            }
            else
            {
                self.View.E_LoginButtonButton.interactable = true;
                self.View.E_LoginTextTextMeshProUGUI.color = new Color(21f / 255f, 27f /255f, 40f /255f, 1);
            }

            // 判断用户账号密码格式是否输入正确，两遍密码是否相同
            if (!Regex.IsMatch(self.View.E_RegisterAccountInputFieldTMP_InputField.text.Trim(), @"^(?=.*[0-9A-Za-z].*).{6,15}$") ||
                !Regex.IsMatch(self.View.E_RegisterPasswordInputFieldTMP_InputField.text.Trim(), @"^(?=.*[0-9A-Za-z].*).{6,15}$") ||
                (self.View.E_RegisterPasswordInputFieldTMP_InputField.text != self.View.E_RegisterPasswordInputField2TMP_InputField.text)
               )
            {
                self.View.E_StartRegisterButtonButton.interactable = false;
            }
            else
            {
                self.View.E_StartRegisterButtonButton.interactable = true;
            }
        }
        
        /// <summary>
        /// 异步登录按键处理
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnLoginClickHandler(this DlgLoginUI self)
        {
            await self.Login(self.View.E_LoginUserTMP_InputField.text, self.View.E_LoginPasswordTMP_InputField.text); //登录
        }

        /// <summary>
        /// 登录
        /// </summary>
        public static async ETTask Login(this DlgLoginUI self, string account, string password)
        {
            try
            {
                //显示登录之后的页面逻辑

                int errorCode = await LoginHelper.LoginGame(self.Root(), account, password); //登录游戏

                if (errorCode != ErrorCode.ERR_Success) //如果获取的不是一个成功的错误码
                {
                    UIPopUpHelper.CreatePopUpWindow(self.Root(), errorCode); //创建错误弹窗
                    return;
                }

                //登录成功后，在本地保留默认登录账号信息
                PlayerPrefs.SetString("Account", account);
                PlayerPrefs.SetString("Password", password);

                UIComponent uIComponent = self.Root().GetComponent<UIComponent>();
                uIComponent.GetDlgLogic<DlgStartGameUI>().IsLogin = true; //设置为登录成功状态
                uIComponent.GetDlgLogic<DlgStartGameUI>().Refresh(); //刷新开始界面
                uIComponent.CloseWindow(WindowID.WindowID_LoginUI); //关闭登录窗口
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        /// <summary>
        /// 开始注册按钮处理
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnStartRegisterClickHandler(this DlgLoginUI self)
        {
            try
            {
                //显示注册之后的页面逻辑

                int errorCode = await LoginHelper.Register(self.Root(), self.View.E_RegisterAccountInputFieldTMP_InputField.text,
                    self.View.E_RegisterPasswordInputFieldTMP_InputField.text,
                    self.View.E_RegisterPasswordInputField2TMP_InputField.text); //登录游戏

                if (errorCode != ErrorCode.ERR_Success) //如果获取的不是一个成功的错误码
                {
                    UIPopUpHelper.CreatePopUpWindow(self.Root(), errorCode); //创建错误弹窗
                    return;
                }

                
                UIComponent uIComponent = self.Root().GetComponent<UIComponent>();
                uIComponent.GetDlgLogic<DlgStartGameUI>().IsLogin = false; //设置为未登录状态
                uIComponent.GetDlgLogic<DlgStartGameUI>().Refresh(); //刷新开始界面
                
                self.OnCutLoginClickHandler(); //切换到登录界面
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        /// <summary>
        /// 切换注册按钮处理
        /// </summary>
        /// <param name="self"></param>
        public static void OnCutRegisterClickHandler(this DlgLoginUI self)
        {
            self.View.EG_RegisterRectTransform.SetVisible(true); //显示注册界面
            self.View.EG_LoginPanelRectTransform.SetVisible(false); //隐藏登录界面
        }

        /// <summary>
        /// 切换登录按钮处理
        /// </summary>
        /// <param name="self"></param>
        public static void OnCutLoginClickHandler(this DlgLoginUI self)
        {
            self.View.EG_LoginPanelRectTransform.SetVisible(true); //显示登录界面
            self.View.EG_RegisterRectTransform.SetVisible(false); //隐藏注册界面
        }
    }
}