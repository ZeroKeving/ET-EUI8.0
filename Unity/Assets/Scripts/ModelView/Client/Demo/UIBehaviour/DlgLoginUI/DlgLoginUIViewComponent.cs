
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLoginUI))]
	[EnableMethod]
	public  class DlgLoginUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_PanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PanelRectTransform == null )
     			{
		    		this.m_EG_PanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Panel");
     			}
     			return this.m_EG_PanelRectTransform;
     		}
     	}

		public TMPro.TextMeshProUGUI ELabel_UsernameTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_UsernameTextMeshProUGUI == null )
     			{
		    		this.m_ELabel_UsernameTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/LoginPanel/ELabel_Username");
     			}
     			return this.m_ELabel_UsernameTextMeshProUGUI;
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
		    		this.m_E_LoginUserTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_Panel/LoginPanel/E_LoginUser");
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
		    		this.m_E_LoginUserImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/LoginPanel/E_LoginUser");
     			}
     			return this.m_E_LoginUserImage;
     		}
     	}

		public TMPro.TextMeshProUGUI ELabel_PasswordTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_PasswordTextMeshProUGUI == null )
     			{
		    		this.m_ELabel_PasswordTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/LoginPanel/ELabel_Password");
     			}
     			return this.m_ELabel_PasswordTextMeshProUGUI;
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
		    		this.m_E_LoginPasswordTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"EG_Panel/LoginPanel/E_LoginPassword");
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
		    		this.m_E_LoginPasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/LoginPanel/E_LoginPassword");
     			}
     			return this.m_E_LoginPasswordImage;
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
		    		this.m_E_LoginButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Panel/E_LoginButton");
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
		    		this.m_E_LoginButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Panel/E_LoginButton");
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
		    		this.m_E_LoginTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/E_LoginButton/E_LoginText");
     			}
     			return this.m_E_LoginTextTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI ELabel_LoginTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_LoginTextMeshProUGUI == null )
     			{
		    		this.m_ELabel_LoginTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Panel/ELabel_Login");
     			}
     			return this.m_ELabel_LoginTextMeshProUGUI;
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

		public TMPro.TextMeshProUGUI E_RegisterTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterTextTextMeshProUGUI == null )
     			{
		    		this.m_E_RegisterTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_RegisterText");
     			}
     			return this.m_E_RegisterTextTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI E_RegisterAccountTitleTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterAccountTitleTextMeshProUGUI == null )
     			{
		    		this.m_E_RegisterAccountTitleTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_RegisterAccountTitle");
     			}
     			return this.m_E_RegisterAccountTitleTextMeshProUGUI;
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

		public TMPro.TextMeshProUGUI E_RegisterPasswordTitleTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordTitleTextMeshProUGUI == null )
     			{
		    		this.m_E_RegisterPasswordTitleTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordTitle");
     			}
     			return this.m_E_RegisterPasswordTitleTextMeshProUGUI;
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

		public TMPro.TextMeshProUGUI E_RegisterPasswordTitle2TextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterPasswordTitle2TextMeshProUGUI == null )
     			{
		    		this.m_E_RegisterPasswordTitle2TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_Register/E_RegisterPasswordTitle2");
     			}
     			return this.m_E_RegisterPasswordTitle2TextMeshProUGUI;
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
		    		this.m_E_CutRegisterButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CutRegisterButton");
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
		    		this.m_E_CutRegisterButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CutRegisterButton");
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
		    		this.m_E_CutRegisterButtonTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_CutRegisterButton/E_CutRegisterButtonText");
     			}
     			return this.m_E_CutRegisterButtonTextTextMeshProUGUI;
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
		    		this.m_E_CutLoginButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CutLoginButton");
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
		    		this.m_E_CutLoginButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CutLoginButton");
     			}
     			return this.m_E_CutLoginButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_CutLoginButtonTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CutLoginButtonTextTextMeshProUGUI == null )
     			{
		    		this.m_E_CutLoginButtonTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_CutLoginButton/E_CutLoginButtonText");
     			}
     			return this.m_E_CutLoginButtonTextTextMeshProUGUI;
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
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CloseButton");
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
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_ELabel_UsernameTextMeshProUGUI = null;
			this.m_E_LoginUserTMP_InputField = null;
			this.m_E_LoginUserImage = null;
			this.m_ELabel_PasswordTextMeshProUGUI = null;
			this.m_E_LoginPasswordTMP_InputField = null;
			this.m_E_LoginPasswordImage = null;
			this.m_E_LoginButtonButton = null;
			this.m_E_LoginButtonImage = null;
			this.m_E_LoginTextTextMeshProUGUI = null;
			this.m_ELabel_LoginTextMeshProUGUI = null;
			this.m_EG_RegisterRectTransform = null;
			this.m_E_RegisterTextTextMeshProUGUI = null;
			this.m_E_RegisterAccountTitleTextMeshProUGUI = null;
			this.m_E_RegisterAccountInputFieldTMP_InputField = null;
			this.m_E_RegisterAccountInputFieldImage = null;
			this.m_E_RegisterAccountPlaceholderTextMeshProUGUI = null;
			this.m_E_RegisterPasswordTitleTextMeshProUGUI = null;
			this.m_E_RegisterPasswordInputFieldTMP_InputField = null;
			this.m_E_RegisterPasswordInputFieldImage = null;
			this.m_E_RegisterPasswordPlaceholderTextMeshProUGUI = null;
			this.m_E_RegisterPasswordTitle2TextMeshProUGUI = null;
			this.m_E_RegisterPasswordInputField2TMP_InputField = null;
			this.m_E_RegisterPasswordInputField2Image = null;
			this.m_E_RegisterPasswordPlaceholder2TextMeshProUGUI = null;
			this.m_E_StartRegisterButtonButton = null;
			this.m_E_StartRegisterButtonImage = null;
			this.m_E_StartRegisterButtonTextTextMeshProUGUI = null;
			this.m_E_CutRegisterButtonButton = null;
			this.m_E_CutRegisterButtonImage = null;
			this.m_E_CutRegisterButtonTextTextMeshProUGUI = null;
			this.m_E_CutLoginButtonButton = null;
			this.m_E_CutLoginButtonImage = null;
			this.m_E_CutLoginButtonTextTextMeshProUGUI = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private TMPro.TextMeshProUGUI m_ELabel_UsernameTextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_LoginUserTMP_InputField = null;
		private UnityEngine.UI.Image m_E_LoginUserImage = null;
		private TMPro.TextMeshProUGUI m_ELabel_PasswordTextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_LoginPasswordTMP_InputField = null;
		private UnityEngine.UI.Image m_E_LoginPasswordImage = null;
		private UnityEngine.UI.Button m_E_LoginButtonButton = null;
		private UnityEngine.UI.Image m_E_LoginButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_LoginTextTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_ELabel_LoginTextMeshProUGUI = null;
		private UnityEngine.RectTransform m_EG_RegisterRectTransform = null;
		private TMPro.TextMeshProUGUI m_E_RegisterTextTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_E_RegisterAccountTitleTextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_RegisterAccountInputFieldTMP_InputField = null;
		private UnityEngine.UI.Image m_E_RegisterAccountInputFieldImage = null;
		private TMPro.TextMeshProUGUI m_E_RegisterAccountPlaceholderTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_E_RegisterPasswordTitleTextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_RegisterPasswordInputFieldTMP_InputField = null;
		private UnityEngine.UI.Image m_E_RegisterPasswordInputFieldImage = null;
		private TMPro.TextMeshProUGUI m_E_RegisterPasswordPlaceholderTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_E_RegisterPasswordTitle2TextMeshProUGUI = null;
		private TMPro.TMP_InputField m_E_RegisterPasswordInputField2TMP_InputField = null;
		private UnityEngine.UI.Image m_E_RegisterPasswordInputField2Image = null;
		private TMPro.TextMeshProUGUI m_E_RegisterPasswordPlaceholder2TextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_StartRegisterButtonButton = null;
		private UnityEngine.UI.Image m_E_StartRegisterButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_StartRegisterButtonTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_CutRegisterButtonButton = null;
		private UnityEngine.UI.Image m_E_CutRegisterButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_CutRegisterButtonTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_CutLoginButtonButton = null;
		private UnityEngine.UI.Image m_E_CutLoginButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_CutLoginButtonTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		public Transform uiTransform = null;
	}
}
