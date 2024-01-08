using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgAwait))]
    public static class DlgAwaitSystem
    {
        public static void RegisterUIEvent(this DlgAwait self)
        {
        }

        public static void ShowWindow(this DlgAwait self, Entity contextData = null)
        {
            self.HideLoadingImage();//初始不显示加载图片
        }

        public static void HideWindow(this DlgAwait self)
        {
            self.HideLoadingImage();//隐藏加载图片
        }

        /// <summary>
        /// 显示加载图片
        /// </summary>
        /// <param name="self"></param>
        public static void ShowLoadingImage(this DlgAwait self)
        {
            self.View.EG_HandleRectTransform.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// 隐藏加载图片
        /// </summary>
        /// <param name="self"></param>
        public static void HideLoadingImage(this DlgAwait self)
        {
            self.View.EG_HandleRectTransform.gameObject.SetActive(false);
            self.View.EG_PanelRectTransform.gameObject.SetActive(false);//关闭点击阻挡
        }

        /// <summary>
        /// 打开点击阻挡
        /// </summary>
        /// <param name="self"></param>
        public static void OpenPanel(this DlgAwait self)
        {
            self.View.EG_PanelRectTransform.gameObject.SetActive(true);//关闭点击阻挡
        }
    }
}