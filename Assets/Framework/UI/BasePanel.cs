using UnityEngine;

namespace Framework.UI
{
    public abstract class BasePanel : MonoBehaviour, IPanel
    {
        //Panel基础信息
        PanelInfo BaseInfo { get; set; }


        public abstract void Enter();

        public abstract void Exit();

        public abstract void Pause();

        public abstract void Resume();
    }
}
