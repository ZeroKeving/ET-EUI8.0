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
    [FriendOf(typeof (DlgStrongPopUpWindow))]
    public static class DlgStrongPopUpWindowSystem
    {
        public static void RegisterUIEvent(this DlgStrongPopUpWindow self)
        {
            //给关闭按钮注册关闭事件
            self.RegisterCloseEvent<DlgStrongPopUpWindow>(self.View.E_CloseButtonButton);
        }

        public static void ShowWindow(this DlgStrongPopUpWindow self, Entity contextData = null)
        {
            self.View.E_TitleTextMeshProUGUI.SetText("错误提示"); //TO DO：未来做多语言需要改为配置实现
        }

        /// <summary>
        /// 显示错误内容
        /// </summary>
        /// <param name="self"></param>
        /// <param name="errorCode"></param>
        public static void ShowContent(this DlgStrongPopUpWindow self, int errorCode)
        {
            int icon = HintMultilingualConfigCategory.Instance.Icon[errorCode]; //获得icon ，todo目前未赋值
            string title = HintMultilingualConfigCategory.Instance.Title[errorCode]; // 获取标题
            string desc = HintMultilingualConfigCategory.Instance.Desc[errorCode]; // 获取描述
            self.View.E_TitleTextMeshProUGUI.SetText(title); // 设置标题
            self.View.E_DescTextMeshProUGUI.SetText(desc); // 设置描述
            //Todo 设置图标
        }
    }
}