namespace Framework.UI
{
    public class InventoryPanel : PopupPanel
    {        
        //进入
        public override void Enter()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }
    }
}

