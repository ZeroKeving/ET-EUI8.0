using DG.Tweening;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgLoadResourceAndLogin :Entity,IAwake,IUILogic
	{

		public DlgLoadResourceAndLoginViewComponent View { get => this.GetComponent<DlgLoadResourceAndLoginViewComponent>();}

		public float ProgressValue;//进度值

		public Sequence TweenLoading = DOTween.Sequence();//tween动画队列

	}
}
