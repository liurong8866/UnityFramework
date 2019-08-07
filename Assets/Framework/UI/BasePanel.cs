using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    public abstract class BasePanel : MonoBehaviour, IPanel
    {
        //面板信息
        public PanelInfo PanelInfo { get; set; }

        //构造函数
        protected virtual void Start() { }

        //进入
        public virtual void Enter() { }

        //暂停
        public virtual void Pause() { }

        //恢复
        public virtual void Resume() { }

        //退出
        public virtual void Exit() { }
        
    }

}
