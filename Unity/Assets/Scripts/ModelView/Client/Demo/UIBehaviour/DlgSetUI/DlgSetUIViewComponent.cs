
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSetUI))]
	[EnableMethod]
	public  class DlgSetUIViewComponent : Entity,IAwake,IDestroy 
	{
		public TMPro.TextMeshProUGUI E_LanguageTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LanguageTextTextMeshProUGUI == null )
     			{
		    		this.m_E_LanguageTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Image/E_LanguageText");
     			}
     			return this.m_E_LanguageTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_CNButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CNButtonButton == null )
     			{
		    		this.m_E_CNButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image/E_CNButton");
     			}
     			return this.m_E_CNButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CNButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CNButtonImage == null )
     			{
		    		this.m_E_CNButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image/E_CNButton");
     			}
     			return this.m_E_CNButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_CNTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CNTextTextMeshProUGUI == null )
     			{
		    		this.m_E_CNTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Image/E_CNButton/E_CNText");
     			}
     			return this.m_E_CNTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_ENButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ENButtonButton == null )
     			{
		    		this.m_E_ENButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image/E_ENButton");
     			}
     			return this.m_E_ENButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ENButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ENButtonImage == null )
     			{
		    		this.m_E_ENButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image/E_ENButton");
     			}
     			return this.m_E_ENButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_ENTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ENTextTextMeshProUGUI == null )
     			{
		    		this.m_E_ENTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"Image/E_ENButton/E_ENText");
     			}
     			return this.m_E_ENTextTextMeshProUGUI;
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
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image/E_CloseButton");
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
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image/E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSelectImage == null )
     			{
		    		this.m_E_ButtonSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonSelect");
     			}
     			return this.m_E_ButtonSelectImage;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonUnSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonUnSelectImage == null )
     			{
		    		this.m_E_ButtonUnSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonUnSelect");
     			}
     			return this.m_E_ButtonUnSelectImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_LanguageTextTextMeshProUGUI = null;
			this.m_E_CNButtonButton = null;
			this.m_E_CNButtonImage = null;
			this.m_E_CNTextTextMeshProUGUI = null;
			this.m_E_ENButtonButton = null;
			this.m_E_ENButtonImage = null;
			this.m_E_ENTextTextMeshProUGUI = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_ButtonSelectImage = null;
			this.m_E_ButtonUnSelectImage = null;
			this.uiTransform = null;
		}

		private TMPro.TextMeshProUGUI m_E_LanguageTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_CNButtonButton = null;
		private UnityEngine.UI.Image m_E_CNButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_CNTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_ENButtonButton = null;
		private UnityEngine.UI.Image m_E_ENButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_ENTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.Image m_E_ButtonSelectImage = null;
		private UnityEngine.UI.Image m_E_ButtonUnSelectImage = null;
		public Transform uiTransform = null;
	}
}
