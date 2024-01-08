using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 错误信息弹窗UI
    /// </summary>
    [FriendOf(typeof (DlgErrorWindow))]
    public static class DlgErrorWindowSystem
    {
        public static void RegisterUIEvent(this DlgErrorWindow self)
        {
            //给关闭按钮注册关闭事件
            self.RegisterCloseEvent<DlgErrorWindow>(self.View.E_CloseButtonButton);
            self.RegisterCloseEvent<DlgErrorWindow>(self.View.E_ClosePanelButton);
        }

        public static void ShowWindow(this DlgErrorWindow self, Entity contextData = null)
        {
            self.View.E_ClosePanelTextTextMeshProUGUI.SetText("点击空白区域关闭"); //TO DO：未来做多语言需要改为配置实现
            self.View.E_TitleTextMeshProUGUI.SetText("错误提示"); //TO DO：未来做多语言需要改为配置实现
            self.View.E_CloseTextTextMeshProUGUI.SetText("确认关闭"); //TO DO：未来做多语言需要改为配置实现
        }

        /// <summary>
        /// 显示错误内容
        /// </summary>
        /// <param name="self"></param>
        /// <param name="errorCode"></param>
        public static void ShowErrorContent(this DlgErrorWindow self, int errorCode)
        {
            string errortText = null;
            switch (errorCode) //TO DO：未来做多语言需要改为配置实现
            {
                case 200002:
                    errortText = "网络异常";
                    break;
                case 200003:
                    errortText = "登录账号密码为空";
                    break;
                case 200004:
                    errortText = "登录账号格式错误";
                    break;
                case 200005:
                    errortText = "登录密码格式错误";
                    break;
                case 200006:
                    errortText = "登录账号属于黑名单";
                    break;
                case 200007:
                    errortText = "登录密码错误";
                    break;
                case 200008:
                    errortText = "频繁请求多次，请稍后再试";
                    break;
                case 200009:
                    errortText = "登录令牌错误";
                    break;
                default:
                    errortText = "未知错误";
                    break;
            }

            self.View.E_ErrorTextTextMeshProUGUI.SetText("错误：" + errortText); //TO DO：未来做多语言需要改为配置实现
        }
    }
}