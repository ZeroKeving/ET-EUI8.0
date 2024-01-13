using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgLoadResourceAndLogin))]
    [EntitySystemOf(typeof(DlgLoadResourceAndLogin))]
    public static partial class DlgLoadResourceAndLoginSystem
    {
        
        [EntitySystem]
        private static void Awake(this ET.Client.DlgLoadResourceAndLogin self)
        {
            
        }
        
        public static void RegisterUIEvent(this DlgLoadResourceAndLogin self)
        {
        }

        public static void ShowWindow(this DlgLoadResourceAndLogin self, Entity contextData = null)
        {
            self.ProgressValue = 0;
            self.View.E_Progress_BarSlider.value = self.ProgressValue;
            self.TweenLoading.Kill(true); //初始化Tween队列
            self.View.E_Loading_ProgressTextMeshProUGUI.SetText("正在加载资源: " + self.ProgressValue.ToString("0") + "%");
            
            self.StartProgressAnimation().Coroutine();//开始加载进度条动画
        }

        /// <summary>
        /// 增加加载值【最大值为100，初始值为25】
        /// </summary>
        /// <param name="self"></param>
        /// <param name="progressValue"></param>
        public static void AddProgressValue(this DlgLoadResourceAndLogin self, float progressValue)
        {
            self.ProgressValue += progressValue;
            float currentValue = self.View.E_Progress_BarSlider.value;
            self.TweenLoading.Kill(true); //初始化Tween队列
            self.TweenLoading = DOTween.Sequence();
            self.TweenLoading.Append(DOTween.To(() => currentValue, x =>
                {
                    self.View.E_Progress_BarSlider.value = x;
                    self.View.E_Loading_ProgressTextMeshProUGUI.SetText("正在加载资源: " + self.ProgressValue.ToString("0") + "%");
                }, self.ProgressValue, 1.5f).SetEase(Ease.InOutQuad).SetUpdate(true)); //加载1.5秒时间，缓动，不受Time.Scale影响

            self.TweenLoading.OnComplete(() =>
            {
                if (self.View.E_Progress_BarSlider.value > 99f)
                {
                    self.ProgressValue = 0;
                    self.CompleteProgress().Coroutine();//播放进度条加载完成动画
                    
                }
            });
        }

        /// <summary>
        /// 进度条开始加载动画
        /// </summary>
        /// <param name="self"></param>
        public async static ETTask StartProgressAnimation(this DlgLoadResourceAndLogin self)
        {
            //播放开启动画
            Animation animation = self.View.EG_Progress_ContentRectTransform.gameObject.GetComponent<Animation>();
            animation.Play("UI_Loading_Show");
            //等待动画播放完成
            await self.Root().GetComponent<TimerComponent>().WaitAsync((long)animation["UI_Loading_Hide"].length * 2000);
            
            self.AddProgressValue(100f);//增加进度值（初始为25，暂时用100代替加载）
        }

        /// <summary>
        /// 进度条加载完成
        /// </summary>
        /// <param name="self"></param>
        public async static ETTask CompleteProgress(this DlgLoadResourceAndLogin self)
        {
            //播放进度条隐藏动画
            Animation animation = self.View.EG_Progress_ContentRectTransform.gameObject.GetComponent<Animation>();
            animation.Play("UI_Loading_Hide");
            //等待进度条动画播放完毕
            await self.Root().GetComponent<TimerComponent>().WaitAsync((long)animation["UI_Loading_Hide"].length * 1500);
            
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_StartGameUI);//打开开始游戏页面
            // self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_LoadResourceAndLogin);//结束后隐藏加载界面
        }
    }
}