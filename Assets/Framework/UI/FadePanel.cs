using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    /// <summary>
    /// 淡入、淡出模式
    /// </summary>
    public class FadePanel : BasePanel, IClosable
    {
        protected CanvasGroup canvasGroup;

        protected override void Start()
        {
            base.Start();

            InitComponent();

            RegisterEvent();
        }

        //进入
        public override void Enter()
        {
            InitComponent();
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
            Transform closeButton = transform.Find(UIConst.CON_BUTTON_CLOSE);

            if (closeButton.IsNullOrEmpty())
            {
                throw new System.Exception("没有找到关闭按钮：" + UIConst.CON_BUTTON_CLOSE);
            }

            UIEvent.Instance.BindEvent(closeButton.gameObject, EventTriggerType.PointerClick, OnClose);
        }

        public virtual void OnClose(BaseEventData data)
        {
            UIManager.Instance.ClosePanel();
        }
    }
}
