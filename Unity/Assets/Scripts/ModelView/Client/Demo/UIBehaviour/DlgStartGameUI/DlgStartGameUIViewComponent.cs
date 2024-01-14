
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

		public TMPro.TextMeshProUGUI E_StartGameTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameTextTextMeshProUGUI == null )
     			{
		    		this.m_E_StartGameTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_StartGameButton/E_StartGameText");
     			}
     			return this.m_E_StartGameTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Button E_ServerChangeButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerChangeButtonButton == null )
     			{
		    		this.m_E_ServerChangeButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_StartGameButton/E_ServerChangeButton");
     			}
     			return this.m_E_ServerChangeButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ServerChangeButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerChangeButtonImage == null )
     			{
		    		this.m_E_ServerChangeButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_StartGameButton/E_ServerChangeButton");
     			}
     			return this.m_E_ServerChangeButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_ServerChangeTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerChangeTextTextMeshProUGUI == null )
     			{
		    		this.m_E_ServerChangeTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_StartGameButton/E_ServerChangeButton/E_ServerChangeText");
     			}
     			return this.m_E_ServerChangeTextTextMeshProUGUI;
     		}
     	}

		public TMPro.TextMeshProUGUI E_ServerInfoTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerInfoTextTextMeshProUGUI == null )
     			{
		    		this.m_E_ServerInfoTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_StartGameButton/E_ServerInfoText");
     			}
     			return this.m_E_ServerInfoTextTextMeshProUGUI;
     		}
     	}

		public UnityEngine.UI.Image E_ServerStatusImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerStatusImage == null )
     			{
		    		this.m_E_ServerStatusImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_StartGameButton/E_ServerStatus");
     			}
     			return this.m_E_ServerStatusImage;
     		}
     	}

		public UnityEngine.UI.Button E_AccountButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AccountButtonButton == null )
     			{
		    		this.m_E_AccountButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_AccountButton");
     			}
     			return this.m_E_AccountButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_AccountButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AccountButtonImage == null )
     			{
		    		this.m_E_AccountButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_AccountButton");
     			}
     			return this.m_E_AccountButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_SetButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetButtonButton == null )
     			{
		    		this.m_E_SetButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_SetButton");
     			}
     			return this.m_E_SetButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetButtonImage == null )
     			{
		    		this.m_E_SetButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_SetButton");
     			}
     			return this.m_E_SetButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SeverListPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SeverListPanelRectTransform == null )
     			{
		    		this.m_EG_SeverListPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SeverListPanel");
     			}
     			return this.m_EG_SeverListPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_ServerInfoLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ServerInfoLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ServerInfoLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_SeverListPanel/Image/ELoopScrollList_ServerInfo");
     			}
     			return this.m_ELoopScrollList_ServerInfoLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_SeverListCloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeverListCloseButtonButton == null )
     			{
		    		this.m_E_SeverListCloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_SeverListPanel/Image/E_SeverListCloseButton");
     			}
     			return this.m_E_SeverListCloseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_SeverListCloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeverListCloseButtonImage == null )
     			{
		    		this.m_E_SeverListCloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_SeverListPanel/Image/E_SeverListCloseButton");
     			}
     			return this.m_E_SeverListCloseButtonImage;
     		}
     	}

		public TMPro.TextMeshProUGUI E_ServerSelectTitleTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerSelectTitleTextMeshProUGUI == null )
     			{
		    		this.m_E_ServerSelectTitleTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"EG_SeverListPanel/Image/E_ServerSelectTitle");
     			}
     			return this.m_E_ServerSelectTitleTextMeshProUGUI;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_StartGameButtonButton = null;
			this.m_E_StartGameButtonImage = null;
			this.m_E_StartGameTextTextMeshProUGUI = null;
			this.m_E_ServerChangeButtonButton = null;
			this.m_E_ServerChangeButtonImage = null;
			this.m_E_ServerChangeTextTextMeshProUGUI = null;
			this.m_E_ServerInfoTextTextMeshProUGUI = null;
			this.m_E_ServerStatusImage = null;
			this.m_E_AccountButtonButton = null;
			this.m_E_AccountButtonImage = null;
			this.m_E_SetButtonButton = null;
			this.m_E_SetButtonImage = null;
			this.m_EG_SeverListPanelRectTransform = null;
			this.m_ELoopScrollList_ServerInfoLoopVerticalScrollRect = null;
			this.m_E_SeverListCloseButtonButton = null;
			this.m_E_SeverListCloseButtonImage = null;
			this.m_E_ServerSelectTitleTextMeshProUGUI = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_StartGameButtonButton = null;
		private UnityEngine.UI.Image m_E_StartGameButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_StartGameTextTextMeshProUGUI = null;
		private UnityEngine.UI.Button m_E_ServerChangeButtonButton = null;
		private UnityEngine.UI.Image m_E_ServerChangeButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_ServerChangeTextTextMeshProUGUI = null;
		private TMPro.TextMeshProUGUI m_E_ServerInfoTextTextMeshProUGUI = null;
		private UnityEngine.UI.Image m_E_ServerStatusImage = null;
		private UnityEngine.UI.Button m_E_AccountButtonButton = null;
		private UnityEngine.UI.Image m_E_AccountButtonImage = null;
		private UnityEngine.UI.Button m_E_SetButtonButton = null;
		private UnityEngine.UI.Image m_E_SetButtonImage = null;
		private UnityEngine.RectTransform m_EG_SeverListPanelRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_ServerInfoLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_SeverListCloseButtonButton = null;
		private UnityEngine.UI.Image m_E_SeverListCloseButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_ServerSelectTitleTextMeshProUGUI = null;
		public Transform uiTransform = null;
	}
}
