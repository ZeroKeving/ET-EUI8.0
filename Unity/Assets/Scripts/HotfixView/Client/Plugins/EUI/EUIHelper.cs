using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    public static class EUIHelper
    {
        #region UI辅助方法

        public static void SetText(this Text Label, string content)
        {
            if (null == Label)
            {
                Log.Error("label is null");
                return;
            }

            Label.text = content;
        }

        public static void SetVisibleWithScale(this UIBehaviour uiBehaviour, bool isVisible)
        {
            if (null == uiBehaviour)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == uiBehaviour.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            if (uiBehaviour.gameObject.activeSelf == isVisible)
            {
                return;
            }

            uiBehaviour.transform.localScale = isVisible? Vector3.one : Vector3.zero;
        }

        public static void SetVisible(this UIBehaviour uiBehaviour, bool isVisible)
        {
            if (null == uiBehaviour)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == uiBehaviour.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            if (uiBehaviour.gameObject.activeSelf == isVisible)
            {
                return;
            }

            uiBehaviour.gameObject.SetActive(isVisible);
        }

        public static void SetVisible(this LoopScrollRect loopScrollRect, bool isVisible, int count = 0)
        {
            loopScrollRect.gameObject.SetActive(isVisible);
            loopScrollRect.totalCount = count;
            loopScrollRect.RefillCells();
        }

        public static void SetVisibleWithScale(this Transform transform, bool isVisible)
        {
            if (null == transform)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == transform.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            transform.localScale = isVisible? Vector3.one : Vector3.zero;
        }

        public static void SetVisible(this Transform transform, bool isVisible)
        {
            if (null == transform)
            {
                Log.Error("uibehaviour is null!");
                return;
            }

            if (null == transform.gameObject)
            {
                Log.Error("uiBehaviour gameObject is null!");
                return;
            }

            if (transform.gameObject.activeSelf == isVisible)
            {
                return;
            }

            transform.gameObject.SetActive(isVisible);
        }

        public static void SetTogglesInteractable(this ToggleGroup toggleGroup, bool isEnable)
        {
            var toggles = toggleGroup.transform.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].interactable = isEnable;
            }
        }

        public static (int, Toggle) GetSelectedToggle(this ToggleGroup toggleGroup)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                if (togglesList[i].isOn)
                {
                    return (i, togglesList[i]);
                }
            }

            Log.Error("none Toggle is Selected");
            return (-1, null);
        }

        public static void SetToggleSelected(this ToggleGroup toggleGroup, int index)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                if (i != index)
                {
                    continue;
                }

                togglesList[i].IsSelected(true);
            }
        }

        public static void IsSelected(this Toggle toggle, bool isSelected)
        {
            toggle.isOn = isSelected;
            toggle.onValueChanged?.Invoke(isSelected);
        }

        public static void RemoveUIScrollItems<K, T>(this K self, ref Dictionary<int, T> dictionary) where K : Entity, IUILogic
                where T : Entity, IUIScrollItem
        {
            if (dictionary == null)
            {
                return;
            }

            foreach (var item in dictionary)
            {
                item.Value.Dispose();
            }

            dictionary.Clear();
            dictionary = null;
        }

        public static void GetUIComponent<T>(this ReferenceCollector rf, string key, ref T t) where T : class
        {
            GameObject obj = rf.Get<GameObject>(key);

            if (obj == null)
            {
                t = null;
                return;
            }

            t = obj.GetComponent<T>();
        }

        #endregion

        #region UI按钮事件

        public static void AddListenerAsyncWithId(this Button button, Func<int, ETTask> action, int id)
        {
            button.onClick.RemoveAllListeners();

            async ETTask clickActionAsync()
            {
                UIEventComponent.Instance?.SetUIClicked(true);
                await action(id);
                UIEventComponent.Instance?.SetUIClicked(false);
            }

            button.onClick.AddListener(() =>
            {
                if (UIEventComponent.Instance == null)
                {
                    return;
                }

                if (UIEventComponent.Instance.IsClicked)
                {
                    return;
                }

                clickActionAsync().Coroutine();
            });
        }
        
        /// <summary>
        /// 异步按键监听
        /// </summary>
        /// <param name="button"></param>
        /// <param name="action"></param>
        /// <param name="self"></param>
        /// <param name="loading"></param>
        public static void AddListenerAsync(this Button button, Func<ETTask> action, Scene root, bool loading = true)
        {
            button.onClick.RemoveAllListeners(); //移除这个按键所有的监听

            async ETTask clickActionAsync()
            {
                UIEventComponent.Instance?.SetUIClicked(true); //在UI事件组件单例里使用异步按键点击事件锁

                UIComponent uiComponent = root.GetComponent<UIComponent>();
                if (loading)
                {
                    DelayedAwaitLoading(uiComponent).Coroutine();//开始延迟显示等待信息弹窗
                }

                await action();

                if (loading)
                {
                    HideAwaitLoading(uiComponent);//关闭等待信息弹窗
                }
                UIEventComponent.Instance?.SetUIClicked(false);//关闭异步按键点击事件锁
            }

            button.onClick.AddListener(() =>
            {
                if (UIEventComponent.Instance == null) //如果UI事件组件没有实例化就直接返回
                {
                    return;
                }

                if (UIEventComponent.Instance.IsClicked)//如果被锁了就返回
                {
                    return;
                }

                clickActionAsync().Coroutine();//以协程的方式启动这个内部方法
            });
        }
        
        /// <summary>
        /// 延迟0.5秒等待加载显示
        /// </summary>
        /// <param name="uiComponent"></param>
        public static async ETTask DelayedAwaitLoading(UIComponent uiComponent)
        {
            if (uiComponent.GetDlgLogic<DlgAwait>() == null)
            {
                uiComponent.ShowWindow(WindowID.WindowID_Await);//显示等待弹窗
                uiComponent.HideWindow(WindowID.WindowID_Await);//隐藏等待弹窗
            }

            uiComponent.GetDlgLogic<DlgAwait>().isNeedAwait = true;//设置为正需要延迟

            await uiComponent.Root().GetComponent<TimerComponent>().WaitAsync(500);//延迟等待0.5秒

            if (uiComponent != null && uiComponent.GetDlgLogic<DlgAwait>().isNeedAwait)
            {
                uiComponent.ShowWindow(WindowID.WindowID_Await);//显示等待弹窗
            }
        }
        
        /// <summary>
        /// 隐藏等待加载显示
        /// </summary>
        /// <param name="uiComponent"></param>
        public static void HideAwaitLoading(UIComponent uiComponent)
        {
            if (uiComponent.GetDlgLogic<DlgAwait>() == null)
            {
                return;
            }

            if (!uiComponent.IsWindowVisible(WindowID.WindowID_Await))//如果等待信息弹窗没有被显示出来
            {
                uiComponent.GetDlgLogic<DlgAwait>().isNeedAwait = false;//关闭延迟显示
            }
            else
            {
                uiComponent.GetDlgLogic<DlgAwait>().isNeedAwait = false;//关闭延迟显示
                uiComponent.HideWindow(WindowID.WindowID_Await);//隐藏等待信息弹窗
            }
        }

        public static void AddListener(this Toggle toggle, UnityAction<bool> selectEventHandler)
        {
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener(selectEventHandler);
        }

        public static void AddListener(this Button button, UnityAction clickEventHandler)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(clickEventHandler);
        }

        public static void AddListenerWithId(this Button button, Action<int> clickEventHandler, int id)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(id); });
        }

        public static void AddListenerWithId(this Button button, Action<long> clickEventHandler, long id)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(id); });
        }

        public static void AddListenerWithParam<T>(this Button button, Action<T> clickEventHandler, T param)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(param); });
        }

        public static void AddListenerWithParam<T, A>(this Button button, Action<T, A> clickEventHandler, T param1, A param2)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { clickEventHandler(param1, param2); });
        }

        public static void AddListener(this ToggleGroup toggleGroup, UnityAction<int> selectEventHandler)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                int index = i;
                togglesList[i].AddListener((isOn) =>
                {
                    if (isOn)
                    {
                        selectEventHandler(index);
                    }
                });
            }
        }

        /// <summary>
        /// 注册窗口关闭事件
        /// </summary>
        /// <OtherParam name="self"></OtherParam>
        /// <OtherParam name="closeButton"></OtherParam>
        public static void RegisterCloseEvent<T>(this Entity self, Button closeButton, bool isClose = false) where T : Entity, IAwake, IUILogic
        {
            closeButton.onClick.RemoveAllListeners();
            if (isClose)
            {
                closeButton.onClick.AddListener(() =>
                {
                    self.Scene().GetComponent<UIComponent>().CloseWindow(self.GetParent<UIBaseWindow>().WindowID);
                });
            }
            else
            {
                closeButton.onClick.AddListener(() =>
                {
                    self.Scene().GetComponent<UIComponent>().HideWindow(self.GetParent<UIBaseWindow>().WindowID);
                });
            }
        }

        public static void RegisterEvent(this EventTrigger trigger, EventTriggerType eventType, UnityAction<BaseEventData> callback)
        {
            EventTrigger.Entry entry = null;

            // 查找是否已经存在要注册的事件
            foreach (EventTrigger.Entry existingEntry in trigger.triggers)
            {
                if (existingEntry.eventID == eventType)
                {
                    entry = existingEntry;
                    break;
                }
            }

            // 如果这个事件不存在，就创建新的实例
            if (entry == null)
            {
                entry = new EventTrigger.Entry();
                entry.eventID = eventType;
            }

            // 添加触发回调并注册事件
            entry.callback.AddListener(callback);
            trigger.triggers.Add(entry);
        }

        #endregion
    }
}