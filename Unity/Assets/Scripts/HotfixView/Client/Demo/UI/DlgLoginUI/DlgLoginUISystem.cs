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
    [FriendOf(typeof(DlgLoginUI))]
    [EntitySystemOf(typeof(DlgLoginUI))]
    public static partial class DlgLoginUISystem
    {

        public static void RegisterUIEvent(this DlgLoginUI self)
        {

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
            if (!Regex.IsMatch(self.View.E_LoginUserTMP_InputField.text.Trim(), @"^(?=.*[0-9A-Za-z].*).{6,15}$") || !Regex.IsMatch(self.View.E_LoginPasswordTMP_InputField.text.Trim(), @"^(?=.*[0-9A-Za-z].*).{6,15}$"))//判断密码是否为6到15位合法字符组成
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


    }
}
