using UnityEngine;

namespace Framework.UI
{
    /// <summary>
    /// 所有UI面板的基类
    /// </summary>
    public abstract class BasePanel : MonoBehaviour
    {
        //面板信息
        public PanelInfo PanelInfo { get; set; }

        //构造函数
        protected virtual void Awake() { }

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
