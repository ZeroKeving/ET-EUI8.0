
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
		public Transform uiTransform = null;
	}
}
