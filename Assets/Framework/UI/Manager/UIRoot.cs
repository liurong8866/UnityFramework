using UnityEngine;

namespace Framework.UI
{
    public class UIRoot : MonoBehaviour
    {
        private void Start()
        {
            PanelManager.Instance.OpenPanel("MainMenuPanel") ;
        }
    }
}
