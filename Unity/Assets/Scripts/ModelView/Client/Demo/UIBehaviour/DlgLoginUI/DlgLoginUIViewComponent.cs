
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLoginUI))]
	[EnableMethod]
	public  class DlgLoginUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_LoginPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LoginPanelRectTransform == null )
     			{
		    		this.m_EG_LoginPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LoginPanel");
     			}
     			return this.m_EG_LoginPanelRectTransform;
     		}
     	}

		public TMPro.TMP_InputField E_LoginUserTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginUserTMP_InputField == null )
     			{
		    		this.m_E_LoginUserTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginUser");
     			}
     			return this.m_E_LoginUserTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image E_LoginUserImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginUserImage == null )
     			{
		    		this.m_E_LoginUserImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginUser");
     			}
     			return this.m_E_LoginUserImage;
     		}
     	}

		public TMPro.TMP_InputField E_LoginPasswordTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginPasswordTMP_InputField == null )
     			{
		    		this.m_E_LoginPasswordTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginPassword");
     			}
     			return this.m_E_LoginPasswordTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image E_LoginPasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginPasswordImage == null )
     			{
		    		this.m_E_LoginPasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginPassword");
     			}
     			return this.m_E_LoginPasswordImage;
     		}
     	}

		public UnityEngine.UI.Button E_CutRegisterButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CutRegisterButtonButton == null )
     			{
		    		this.m_E_CutRegisterButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LoginPanel/E_CutRegisterButton");
     			}
     			return this.m_E_CutRegisterButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CutRegisterButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CutRegisterButtonImage == null )
     			{
		    		this.m_E_CutRegisterButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LoginPanel/E_CutRegisterButton");
     			}
     			return this.m_E_CutRegisterButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_CutRegisterButtonTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CutRegisterButtonTextTextMeshProUGUI == null )
     			{
		    		this.m_E_CutRegisterButtonTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_LoginPanel/E_CutRegisterButton/E_CutRegisterButtonText");
     			}
     			return this.m_E_CutRegisterButtonTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_LoginButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginButtonButton == null )
     			{
		    		this.m_E_LoginButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginButton");
     			}
     			return this.m_E_LoginButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_LoginButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginButtonImage == null )
     			{
		    		this.m_E_LoginButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginButton");
     			}
     			return this.m_E_LoginButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_LoginTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginTextTextMeshProUGUI == null )
     			{
		    		this.m_E_LoginTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginButton/E_LoginText");
     			}
     			return this.m_E_LoginTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_LoginCloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginCloseButtonButton == null )
     			{
		    		this.m_E_LoginCloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginCloseButton");
     			}
     			return this.m_E_LoginCloseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_LoginCloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginCloseButtonImage == null )
     			{
		    		this.m_E_LoginCloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LoginPanel/E_LoginCloseButton");
     			}
     			return this.m_E_LoginCloseButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RegisterRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RegisterRectTransform == null )
     			{
		    		this.m_EG_RegisterRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Register");
     			}
     			return this.m_EG_RegisterRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_CutLoginButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CutLoginButtonButton == null )
     			{
		    		this.m_E_CutLoginButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Register/E_CutLoginButton");
     			}
     			return this.m_E_CutLoginButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CutLoginButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CutLoginButtonImage == null )
     			{
		    		this.m_E_CutLoginButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Register/E_CutLoginButton");
     			}
     			return this.m_E_CutLoginButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_BackLoginButtonTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BackLoginButtonTextTextMeshProUGUI == null )
     			{
		    		this.m_E_BackLoginButtonTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_CutLoginButton/E_BackLoginButtonText");
     			}
     			return this.m_E_BackLoginButtonTextTextMeshProUGUI;
     		}
     	}

		public TMPro.TMP_InputField E_RegisterAccountInputFieldTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterAccountInputFieldTMP_InputField == null )
     			{
		    		this.m_E_RegisterAccountInputFieldTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_Register/E_RegisterAccountInputField");
     			}
     			return this.m_E_RegisterAccountInputFieldTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image E_RegisterAccountInputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterAccountInputFieldImage == null )
     			{
		    		this.m_E_RegisterAccountInputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Register/E_RegisterAccountInputField");
     			}
     			return this.m_E_RegisterAccountInputFieldImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_RegisterAccountPlaceholderTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterAccountPlaceholderTextMeshProUGUI == null )
     			{
		    		this.m_E_RegisterAccountPlaceholderTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_RegisterAccountInputField/Text Area/E_RegisterAccountPlaceholder");
     			}
     			return this.m_E_RegisterAccountPlaceholderTextMeshProUGUI;
     		}
     	}

		public TMPro.TMP_InputField E_RegisterPasswordInputFieldTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordInputFieldTMP_InputField == null )
     			{
		    		this.m_E_RegisterPasswordInputFieldTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordInputField");
     			}
     			return this.m_E_RegisterPasswordInputFieldTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image E_RegisterPasswordInputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordInputFieldImage == null )
     			{
		    		this.m_E_RegisterPasswordInputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordInputField");
     			}
     			return this.m_E_RegisterPasswordInputFieldImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_RegisterPasswordPlaceholderTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordPlaceholderTextMeshProUGUI == null )
     			{
		    		this.m_E_RegisterPasswordPlaceholderTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordInputField/Text Area/E_RegisterPasswordPlaceholder");
     			}
     			return this.m_E_RegisterPasswordPlaceholderTextMeshProUGUI;
     		}
     	}

		public TMPro.TMP_InputField E_RegisterPasswordInputField2TMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordInputField2TMP_InputField == null )
     			{
		    		this.m_E_RegisterPasswordInputField2TMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordInputField2");
     			}
     			return this.m_E_RegisterPasswordInputField2TMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image E_RegisterPasswordInputField2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordInputField2Image == null )
     			{
		    		this.m_E_RegisterPasswordInputField2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordInputField2");
     			}
     			return this.m_E_RegisterPasswordInputField2Image;
     		}
     	}

		public TMPro.TextMeshProUGUI E_RegisterPasswordPlaceholder2TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordPlaceholder2TextMeshProUGUI == null )
     			{
		    		this.m_E_RegisterPasswordPlaceholder2TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordInputField2/Text Area/E_RegisterPasswordPlaceholder2");
     			}
     			return this.m_E_RegisterPasswordPlaceholder2TextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_StartRegisterButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartRegisterButtonButton == null )
     			{
		    		this.m_E_StartRegisterButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Register/E_StartRegisterButton");
     			}
     			return this.m_E_StartRegisterButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartRegisterButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartRegisterButtonImage == null )
     			{
		    		this.m_E_StartRegisterButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Register/E_StartRegisterButton");
     			}
     			return this.m_E_StartRegisterButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_StartRegisterButtonTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartRegisterButtonTextTextMeshProUGUI == null )
     			{
		    		this.m_E_StartRegisterButtonTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_StartRegisterButton/E_StartRegisterButtonText");
     			}
     			return this.m_E_StartRegisterButtonTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_RegisterCloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterCloseButtonButton == null )
     			{
		    		this.m_E_RegisterCloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Register/E_RegisterCloseButton");
     			}
     			return this.m_E_RegisterCloseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_RegisterCloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterCloseButtonImage == null )
     			{
		    		this.m_E_RegisterCloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Register/E_RegisterCloseButton");
     			}
     			return this.m_E_RegisterCloseButtonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_LoginPanelRectTransform = null;
			this.m_E_LoginUserTMP_InputField = null;
			this.m_E_LoginUserImage = null;
			this.m_E_LoginPasswordTMP_InputField = null;
			this.m_E_LoginPasswordImage = null;
			this.m_E_CutRegisterButtonButton = null;
			this.m_E_CutRegisterButtonImage = null;
			this.m_E_CutRegisterButtonTextTextMeshProUGUI = null;
			this.m_E_LoginButtonButton = null;
			this.m_E_LoginButtonImage = null;
			this.m_E_LoginTextTextMeshProUGUI = null;
			this.m_E_LoginCloseButtonButton = null;
			this.m_E_LoginCloseButtonImage = null;
			this.m_EG_RegisterRectTransform = null;
			this.m_E_CutLoginButtonButton = null;
			this.m_E_CutLoginButtonImage = null;
			this.m_E_BackLoginButtonTextTextMeshProUGUI = null;
			this.m_E_RegisterAccountInputFieldTMP_InputField = null;
			this.m_E_RegisterAccountInputFieldImage = null;
			this.m_E_RegisterAccountPlaceholderTextMeshProUGUI = null;
			this.m_E_RegisterPasswordInputFieldTMP_InputField = null;
			this.m_E_RegisterPasswordInputFieldImage = null;
			this.m_E_RegisterPasswordPlaceholderTextMeshProUGUI = null;
			this.m_E_RegisterPasswordInputField2TMP_InputField = null;
			this.m_E_RegisterPasswordInputField2Image = null;
			this.m_E_RegisterPasswordPlaceholder2TextMeshProUGUI = null;
			this.m_E_StartRegisterButtonButton = null;
			this.m_E_StartRegisterButtonImage = null;
			this.m_E_StartRegisterButtonTextTextMeshProUGUI = null;
			this.m_E_RegisterCloseButtonButton = null;
			this.m_E_RegisterCloseButtonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LoginPanelRectTransform = null;
		private TMPro.TMP_InputField m_E_LoginUserTMP_InputField = null;
		private UnityEngine.UI.Image m_E_LoginUserImage = null;
		private TMPro.TMP_InputField m_E_LoginPasswordTMP_InputField = null;
		private UnityEngine.UI.Image m_E_LoginPasswordImage = null;
		private UnityEngine.UI.Button m_E_CutRegisterButtonButton = null;
		private UnityEngine.UI.Image m_E_CutRegisterButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_CutRegisterButtonTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_LoginButtonButton = null;
		private UnityEngine.UI.Image m_E_LoginButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_LoginTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_LoginCloseButtonButton = null;
		private UnityEngine.UI.Image m_E_LoginCloseButtonImage = null;
		private UnityEngine.RectTransform m_EG_RegisterRectTransform = null;
		private UnityEngine.UI.Button m_E_CutLoginButtonButton = null;
		private UnityEngine.UI.Image m_E_CutLoginButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_BackLoginButtonTextTextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_RegisterAccountInputFieldTMP_InputField = null;
		private UnityEngine.UI.Image m_E_RegisterAccountInputFieldImage = null;
		private TMPro.TextMeshProUGUI m_E_RegisterAccountPlaceholderTextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_RegisterPasswordInputFieldTMP_InputField = null;
		private UnityEngine.UI.Image m_E_RegisterPasswordInputFieldImage = null;
		private TMPro.TextMeshProUGUI m_E_RegisterPasswordPlaceholderTextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_RegisterPasswordInputField2TMP_InputField = null;
		private UnityEngine.UI.Image m_E_RegisterPasswordInputField2Image = null;
		private TMPro.TextMeshProUGUI m_E_RegisterPasswordPlaceholder2TextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_StartRegisterButtonButton = null;
		private UnityEngine.UI.Image m_E_StartRegisterButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_StartRegisterButtonTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_RegisterCloseButtonButton = null;
		private UnityEngine.UI.Image m_E_RegisterCloseButtonImage = null;
		public Transform uiTransform = null;
	}
}
