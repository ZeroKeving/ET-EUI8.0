
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgErrorWindow))]
	[EnableMethod]
	public  class DlgErrorWindowViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ClosePanelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ClosePanelButton == null )
     			{
		    		this.m_E_ClosePanelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ClosePanel");
     			}
     			return this.m_E_ClosePanelButton;
     		}
     	}

		public UnityEngine.UI.Image E_ClosePanelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ClosePanelImage == null )
     			{
		    		this.m_E_ClosePanelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ClosePanel");
     			}
     			return this.m_E_ClosePanelImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_ClosePanelTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ClosePanelTextTextMeshProUGUI == null )
     			{
		    		this.m_E_ClosePanelTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ClosePanel/E_ClosePanelText");
     			}
     			return this.m_E_ClosePanelTextTextMeshProUGUI;
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
		    		this.m_E_TitleTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ClosePanel/Image/E_Title");
     			}
     			return this.m_E_TitleTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI E_ErrorTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ErrorTextTextMeshProUGUI == null )
     			{
		    		this.m_E_ErrorTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ClosePanel/E_ErrorText");
     			}
     			return this.m_E_ErrorTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonButton == null )
     			{
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ClosePanel/E_CloseButton");
     			}
     			return this.m_E_CloseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonImage == null )
     			{
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ClosePanel/E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_CloseTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseTextTextMeshProUGUI == null )
     			{
		    		this.m_E_CloseTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ClosePanel/E_CloseButton/E_CloseText");
     			}
     			return this.m_E_CloseTextTextMeshProUGUI;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ClosePanelButton = null;
			this.m_E_ClosePanelImage = null;
			this.m_E_ClosePanelTextTextMeshProUGUI = null;
			this.m_E_TitleTextMeshProUGUI = null;
			this.m_E_ErrorTextTextMeshProUGUI = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_CloseTextTextMeshProUGUI = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ClosePanelButton = null;
		private UnityEngine.UI.Image m_E_ClosePanelImage = null;
		private TMPro.TextMeshProUGUI m_E_ClosePanelTextTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_E_TitleTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_E_ErrorTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_CloseTextTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
