using UnityEngine;

namespace Framework.UI
{
    public abstract class BasePanel : MonoBehaviour, IPanel
    {
        //Panel基础信息
        public PanelInfo PanelInfo { get; set; }
        
        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }

        public virtual void Pause()
        {

        }

        public virtual void Resume()
        {

        }
    }
}
