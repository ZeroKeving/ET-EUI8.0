using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 创建角色UI界面
    /// </summary>
    [FriendOf(typeof(DlgCreateRole))]
    [EntitySystemOf(typeof(DlgCreateRole))]
    public static partial class DlgCreateRoleSystem
    {

        public static void RegisterUIEvent(this DlgCreateRole self)
        {
            self.View.E_CreateRoleButtonButton.AddListenerAsync(() => { return self.OnCreateRoleClickHandler(); }, self.Root());//创建角色按钮监听
        }

        public static void ShowWindow(this DlgCreateRole self, Entity contextData = null)
        {
        }
        
        [EntitySystem]
        private static void Awake(this ET.Client.DlgCreateRole self)
        {

        }
        [EntitySystem]
        private static void Update(this ET.Client.DlgCreateRole self)
        {
            if (Regex.IsMatch(self.View.E_InputFieldTMP_InputField.text.Trim(), @"^([\u4e00-\u9fa5]{1,8}|[a-zA-Z0-9]{1,16})$"))//判断名称是否为混合输入的1~8位的中文或是1~16位的数字和英文
            {
                self.View.E_CreateRoleButtonButton.interactable = true;
            }
            else
            {
                self.View.E_CreateRoleButtonButton.interactable = false;
            }
        }
        
        /// <summary>
        /// 创建角色按键处理
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnCreateRoleClickHandler(this DlgCreateRole self)
        {
            string name = self.View.E_InputFieldTMP_InputField.text;

            if (!Regex.IsMatch(self.View.E_InputFieldTMP_InputField.text.Trim(), @"^([\u4e00-\u9fa5]{1,8}|[a-zA-Z0-9]{1,16})$"))//名称不合法
            {
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.Root(), name); //创建角色

                if (errorCode != ErrorCode.ERR_Success) //如果获取的不是一个成功的错误码
                {
                    UIPopUpHelper.CreatePopUpWindow(self.Root(), errorCode); //创建错误弹窗
                    return;
                }
                
                //角色创建成功
                UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                uiComponent.ShowWindow(WindowID.WindowID_InitialInterface); //显示游戏初始界面
                uiComponent.CloseWindow(WindowID.WindowID_CreateRole); //关闭创建角色界面
                
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

        }
    }
}
