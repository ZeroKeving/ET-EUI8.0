
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCreateRole))]
	[EnableMethod]
	public  class DlgCreateRoleViewComponent : Entity,IAwake,IDestroy 
	{
		public TMPro.TMP_InputField E_InputFieldTMP_InputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldTMP_InputField == null )
     			{
		    		this.m_E_InputFieldTMP_InputField = UIFindHelper.FindDeepChild<TMPro.TMP_InputField>(this.uiTransform.gameObject,"E_InputField");
     			}
     			return this.m_E_InputFieldTMP_InputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldImage == null )
     			{
		    		this.m_E_InputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_InputField");
     			}
     			return this.m_E_InputFieldImage;
     		}
     	}

		public UnityEngine.UI.Button E_CreateRoleButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleButtonButton == null )
     			{
		    		this.m_E_CreateRoleButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CreateRoleButton");
     			}
     			return this.m_E_CreateRoleButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CreateRoleButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleButtonImage == null )
     			{
		    		this.m_E_CreateRoleButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CreateRoleButton");
     			}
     			return this.m_E_CreateRoleButtonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_InputFieldTMP_InputField = null;
			this.m_E_InputFieldImage = null;
			this.m_E_CreateRoleButtonButton = null;
			this.m_E_CreateRoleButtonImage = null;
			this.uiTransform = null;
		}

		private TMPro.TMP_InputField m_E_InputFieldTMP_InputField = null;
		private UnityEngine.UI.Image m_E_InputFieldImage = null;
		private UnityEngine.UI.Button m_E_CreateRoleButtonButton = null;
		private UnityEngine.UI.Image m_E_CreateRoleButtonImage = null;
		public Transform uiTransform = null;
	}
}
