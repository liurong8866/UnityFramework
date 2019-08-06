using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    public class MainMenuPanel : BasePanel
    {
        public GameObject taskButton;
        public GameObject inventoryButton;
        public GameObject battleButton;
        public GameObject skillButton;
        public GameObject shopButton;
        public GameObject systemButton;

        protected override void Start()
        {
            base.Start();

            UIEvent.Instance.BindEvent(taskButton, EventTriggerType.PointerClick, OnTaskClick);
            UIEvent.Instance.BindEvent(inventoryButton, EventTriggerType.PointerClick, OnInventoryClick);
            UIEvent.Instance.BindEvent(battleButton, EventTriggerType.PointerClick, OnBattleClick);
            UIEvent.Instance.BindEvent(skillButton, EventTriggerType.PointerClick, OnSkillClick);
            UIEvent.Instance.BindEvent(shopButton, EventTriggerType.PointerClick, OnShopClick);
            UIEvent.Instance.BindEvent(systemButton, EventTriggerType.PointerClick, OnSystemClick);
        }

        public void OnTaskClick(BaseEventData data)
        {
            UIManager.Instance.OpenPanel("TaskPanel");
        }

        public void OnInventoryClick(BaseEventData data)
        {
            UIManager.Instance.OpenPanel("InventoryPanel");
        }

        public void OnBattleClick(BaseEventData data)
        {
            "进入战场".Log();
        }

        public void OnSkillClick(BaseEventData data)
        {
            UIManager.Instance.OpenPanel("SkillPanel");
        }

        public void OnShopClick(BaseEventData data)
        {
            UIManager.Instance.OpenPanel("ShopPanel");
        }

        public void OnSystemClick(BaseEventData data)
        {
            UIManager.Instance.OpenPanel("SystemPanel");
        }
    }
}

