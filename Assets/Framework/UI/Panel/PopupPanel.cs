using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    /// <summary>
    /// 淡入、淡出模式
    /// </summary>
    public class PopupPanel : DragablePanel, IClosable
    {
        protected CanvasGroup canvasGroup;

        protected override void Awake()
        {
            base.Awake();

            InitComponent();

            RegisterEvent();
        }

        //进入
        public override void Enter()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }

        //暂停
        public override void Pause()
        {
            canvasGroup.blocksRaycasts = false;
        }

        //恢复
        public override void Resume()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }

        //退出
        public override void Exit()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }

        //实现IClosable
        public virtual void OnClose(BaseEventData data)
        {
            PanelManager.Instance.ClosePanel();
        }

        //初始化组件
        private void InitComponent()
        {
            canvasGroup = transform.GetComponent<CanvasGroup>();

            if (canvasGroup.IsNullOrEmpty())
            {
                canvasGroup = transform.gameObject.AddComponent<CanvasGroup>();
            }

            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;

        }

        //注册事件
        private void RegisterEvent()
        {
            //CloseButton 注册事件
            Transform closeButton = transform.Find(this.CloseButtonPath);

            if (closeButton.IsNullOrEmpty())
            {
                throw new System.Exception("没有找到关闭按钮：" + this.CloseButtonPath);
            }

            UIEvent.Instance.BindEvent(closeButton.gameObject, EventTriggerType.PointerClick, OnClose);
        }

        protected virtual string CloseButtonPath
        {
            get { return UIConst.CON_BUTTON_CLOSE; }
        }

    }
}
