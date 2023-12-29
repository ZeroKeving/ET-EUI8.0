using System.Collections;
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
    [FriendOf(typeof (ShowWindowData))]
    [EntitySystemOf(typeof (DlgLoginUI))]
    public static partial class DlgLoginUISystem
    {
        /// <summary>
        /// 登记UI事件
        /// </summary>
        /// <param name="self"></param>
        public static void RegisterUIEvent(this DlgLoginUI self)
        {
            self.View.E_LoginButtonButton.AddListenerAsync(() => { return self.OnLoginClickHandler(); }, self.Root()); //异步监听登录按键
        }

        public static void ShowWindow(this DlgLoginUI self, Entity contextData = null)
        {
            //从本地获取默认登录账号信息
            self.View.E_LoginUserTMP_InputField.text = PlayerPrefs.GetString("Account", string.Empty);
            self.View.E_LoginPasswordTMP_InputField.text = PlayerPrefs.GetString("Password", string.Empty);
            
            self.PlayAnimation();//播放界面动画
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
                self.View.E_LoginTextTextMeshProUGUI.color = new Color(1, 246f / 255f, 229f / 255f, 1);
            }
        }

        /// <summary>
        /// 播放登录界面动画
        /// </summary>
        /// <param name="self"></param>
        public static void PlayAnimation(this DlgLoginUI self)
        {
            self.View.EG_PanelRectTransform.GetComponent<Animation>().Play("UI_Login_Show");
        }

        /// <summary>
        /// 异步登录按键处理
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnLoginClickHandler(this DlgLoginUI self)
        {
            string account = self.View.E_LoginUserTMP_InputField.text;//账号
            string password = self.View.E_LoginPasswordTMP_InputField.text;//密码
            
            try
            {
                await ETTask.CompletedTask;
                //显示登录之后的页面逻辑

                int errorCode = await LoginHelper.LoginGame(self.Root(), account, password);//登录游戏

                if (errorCode != ErrorCode.ERR_Success)//如果获取的不是一个成功的错误码
                {
                    UIPopUpHelper.CreateErrorWindow(self.Root(),errorCode);//创建错误弹窗
                    return;
                }
                
                //登录成功后，在本地保留默认登录账号信息
                PlayerPrefs.SetString("Account",account);
                PlayerPrefs.SetString("Password",password);
                
                UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                uiComponent.ShowWindow(WindowID.WindowID_InitialInterface); //显示游戏初始界面
                uiComponent.CloseWindow(WindowID.WindowID_LoginUI); //关闭登录窗口
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
        
    }
}