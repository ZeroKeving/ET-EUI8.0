
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgToast))]
	[EnableMethod]
	public  class DlgToastViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_ToastRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ToastRectTransform == null )
     			{
		    		this.m_EG_ToastRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_ToastPanel/EG_Toast");
     			}
     			return this.m_EG_ToastRectTransform;
     		}
     	}

		public TMPro.TextMeshProUGUI E_TitleTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleTextMeshProUGUI == null )
     			{
		    		this.m_E_TitleTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ToastPanel/EG_Toast/E_Title");
     			}
     			return this.m_E_TitleTextMeshProUGUI;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_ToastRectTransform = null;
			this.m_E_TitleTextMeshProUGUI = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_ToastRectTransform = null;
		private TMPro.TextMeshProUGUI m_E_TitleTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
