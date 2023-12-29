
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLoadResourceAndLogin))]
	[EnableMethod]
	public  class DlgLoadResourceAndLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_ContentRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ContentRectTransform == null )
     			{
		    		this.m_EG_ContentRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Content");
     			}
     			return this.m_EG_ContentRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_LogoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LogoImage == null )
     			{
		    		this.m_E_LogoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Content/E_Logo");
     			}
     			return this.m_E_LogoImage;
     		}
     	}

		public UnityEngine.RectTransform EG_Progress_ContentRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Progress_ContentRectTransform == null )
     			{
		    		this.m_EG_Progress_ContentRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Content/EG_Progress_Content");
     			}
     			return this.m_EG_Progress_ContentRectTransform;
     		}
     	}

		public TMPro.TextMeshProUGUI E_Loading_ProgressTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Loading_ProgressTextMeshProUGUI == null )
     			{
		    		this.m_E_Loading_ProgressTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Content/EG_Progress_Content/E_Loading_Progress");
     			}
     			return this.m_E_Loading_ProgressTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Slider E_Progress_BarSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Progress_BarSlider == null )
     			{
		    		this.m_E_Progress_BarSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"EG_Content/EG_Progress_Content/E_Progress/E_Progress_Bar");
     			}
     			return this.m_E_Progress_BarSlider;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_ContentRectTransform = null;
			this.m_E_LogoImage = null;
			this.m_EG_Progress_ContentRectTransform = null;
			this.m_E_Loading_ProgressTextMeshProUGUI = null;
			this.m_E_Progress_BarSlider = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_ContentRectTransform = null;
		private UnityEngine.UI.Image m_E_LogoImage = null;
		private UnityEngine.RectTransform m_EG_Progress_ContentRectTransform = null;
		private TMPro.TextMeshProUGUI m_E_Loading_ProgressTextMeshProUGUI = null;
		private UnityEngine.UI.Slider m_E_Progress_BarSlider = null;
		public Transform uiTransform = null;
	}
}
