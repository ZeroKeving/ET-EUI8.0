
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgStrongPopUpWindow))]
	[EnableMethod]
	public  class DlgStrongPopUpWindowViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ClosePanel/Image/E_CloseButton");
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
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ClosePanel/Image/E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_DescTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DescTextMeshProUGUI == null )
     			{
		    		this.m_E_DescTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ClosePanel/Image/E_Desc");
     			}
     			return this.m_E_DescTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ClosePanel/Image/E_Icon");
     			}
     			return this.m_E_IconImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ClosePanelImage = null;
			this.m_E_TitleTextMeshProUGUI = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_DescTextMeshProUGUI = null;
			this.m_E_IconImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ClosePanelImage = null;
		private TMPro.TextMeshProUGUI m_E_TitleTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_DescTextMeshProUGUI = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		public Transform uiTransform = null;
	}
}
