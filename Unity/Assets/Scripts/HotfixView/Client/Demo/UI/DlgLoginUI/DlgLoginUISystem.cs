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
        /// 异步登录按键处理
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnLoginClickHandler(this DlgLoginUI self)
        {
            try
            {
                await ETTask.CompletedTask;
                //显示登录之后的页面逻辑
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