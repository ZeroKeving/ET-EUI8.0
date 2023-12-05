
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgInitialInterface))]
	[EnableMethod]
	public  class DlgInitialInterfaceViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_StartMatchingButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartMatchingButtonButton == null )
     			{
		    		this.m_E_StartMatchingButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_StartMatchingButton");
     			}
     			return this.m_E_StartMatchingButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartMatchingButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartMatchingButtonImage == null )
     			{
		    		this.m_E_StartMatchingButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_StartMatchingButton");
     			}
     			return this.m_E_StartMatchingButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_CreateRoomButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoomButtonButton == null )
     			{
		    		this.m_E_CreateRoomButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CreateRoomButton");
     			}
     			return this.m_E_CreateRoomButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CreateRoomButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoomButtonImage == null )
     			{
		    		this.m_E_CreateRoomButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CreateRoomButton");
     			}
     			return this.m_E_CreateRoomButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_JoinRoomButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JoinRoomButtonButton == null )
     			{
		    		this.m_E_JoinRoomButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_JoinRoomButton");
     			}
     			return this.m_E_JoinRoomButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_JoinRoomButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JoinRoomButtonImage == null )
     			{
		    		this.m_E_JoinRoomButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_JoinRoomButton");
     			}
     			return this.m_E_JoinRoomButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_StoreButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreButtonButton == null )
     			{
		    		this.m_E_StoreButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_StoreButton");
     			}
     			return this.m_E_StoreButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_StoreButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreButtonImage == null )
     			{
		    		this.m_E_StoreButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_StoreButton");
     			}
     			return this.m_E_StoreButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_FriendListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FriendListRectTransform == null )
     			{
		    		this.m_EG_FriendListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_FriendList");
     			}
     			return this.m_EG_FriendListRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_StartMatchingButtonButton = null;
			this.m_E_StartMatchingButtonImage = null;
			this.m_E_CreateRoomButtonButton = null;
			this.m_E_CreateRoomButtonImage = null;
			this.m_E_JoinRoomButtonButton = null;
			this.m_E_JoinRoomButtonImage = null;
			this.m_E_StoreButtonButton = null;
			this.m_E_StoreButtonImage = null;
			this.m_EG_FriendListRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_StartMatchingButtonButton = null;
		private UnityEngine.UI.Image m_E_StartMatchingButtonImage = null;
		private UnityEngine.UI.Button m_E_CreateRoomButtonButton = null;
		private UnityEngine.UI.Image m_E_CreateRoomButtonImage = null;
		private UnityEngine.UI.Button m_E_JoinRoomButtonButton = null;
		private UnityEngine.UI.Image m_E_JoinRoomButtonImage = null;
		private UnityEngine.UI.Button m_E_StoreButtonButton = null;
		private UnityEngine.UI.Image m_E_StoreButtonImage = null;
		private UnityEngine.RectTransform m_EG_FriendListRectTransform = null;
		public Transform uiTransform = null;
	}
}
