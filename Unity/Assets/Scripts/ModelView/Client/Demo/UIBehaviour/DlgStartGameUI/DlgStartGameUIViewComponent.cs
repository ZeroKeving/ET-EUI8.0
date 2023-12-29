
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgStartGameUI))]
	[EnableMethod]
	public  class DlgStartGameUIViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_StartGameButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameButtonButton == null )
     			{
		    		this.m_E_StartGameButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_StartGameButton");
     			}
     			return this.m_E_StartGameButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartGameButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameButtonImage == null )
     			{
		    		this.m_E_StartGameButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_StartGameButton");
     			}
     			return this.m_E_StartGameButtonImage;
     		}
     	}

		public UnityEngine.UI.Dropdown E_ServerInfoListDropdown
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerInfoListDropdown == null )
     			{
		    		this.m_E_ServerInfoListDropdown = UIFindHelper.FindDeepChild<UnityEngine.UI.Dropdown>(this.uiTransform.gameObject,"E_ServerInfoList");
     			}
     			return this.m_E_ServerInfoListDropdown;
     		}
     	}

		public UnityEngine.UI.Image E_ServerInfoListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerInfoListImage == null )
     			{
		    		this.m_E_ServerInfoListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ServerInfoList");
     			}
     			return this.m_E_ServerInfoListImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_StartGameButtonButton = null;
			this.m_E_StartGameButtonImage = null;
			this.m_E_ServerInfoListDropdown = null;
			this.m_E_ServerInfoListImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_StartGameButtonButton = null;
		private UnityEngine.UI.Image m_E_StartGameButtonImage = null;
		private UnityEngine.UI.Dropdown m_E_ServerInfoListDropdown = null;
		private UnityEngine.UI.Image m_E_ServerInfoListImage = null;
		public Transform uiTransform = null;
	}
}
