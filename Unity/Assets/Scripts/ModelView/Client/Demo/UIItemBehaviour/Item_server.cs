
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_server : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_server BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_ServerButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ServerButtonButton == null )
     				{
		    			this.m_E_ServerButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ServerButton");
     				}
     				return this.m_E_ServerButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ServerButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ServerButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ServerButtonImage == null )
     				{
		    			this.m_E_ServerButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ServerButton");
     				}
     				return this.m_E_ServerButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ServerButton");
     			}
     		}
     	}

		public TMPro.TextMeshProUGUI E_ServerTextTextMeshProUGUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ServerTextTextMeshProUGUI == null )
     				{
		    			this.m_E_ServerTextTextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ServerButton/E_ServerText");
     				}
     				return this.m_E_ServerTextTextMeshProUGUI;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject,"E_ServerButton/E_ServerText");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ServerStatusImage == null )
     				{
		    			this.m_E_ServerStatusImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ServerButton/E_ServerStatus");
     				}
     				return this.m_E_ServerStatusImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ServerButton/E_ServerStatus");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ServerButtonButton = null;
			this.m_E_ServerButtonImage = null;
			this.m_E_ServerTextTextMeshProUGUI = null;
			this.m_E_ServerStatusImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ServerButtonButton = null;
		private UnityEngine.UI.Image m_E_ServerButtonImage = null;
		private TMPro.TextMeshProUGUI m_E_ServerTextTextMeshProUGUI = null;
		private UnityEngine.UI.Image m_E_ServerStatusImage = null;
		public Transform uiTransform = null;
	}
}
