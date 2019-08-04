using UnityEngine;

namespace Framework.UI
{
    public class UIRoot : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance.ShowPanel("TaskPanel") ;
        }
    }
}
