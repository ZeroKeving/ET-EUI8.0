
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgAwait))]
	[EnableMethod]
	public  class DlgAwaitViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.RectTransform EG_HandleRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HandleRectTransform == null )
     			{
		    		this.m_EG_HandleRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Handle");
     			}
     			return this.m_EG_HandleRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PanelRectTransform = null;
			this.m_EG_HandleRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PanelRectTransform = null;
		private UnityEngine.RectTransform m_EG_HandleRectTransform = null;
		public Transform uiTransform = null;
	}
}
