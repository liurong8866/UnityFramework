using UnityEngine;

namespace Framework.UI
{
    public abstract class SlidePanel : BasePanel
    {
        //进入
        public override void Enter() { }

        //暂停
        public override void Exit() { }

        //恢复
        public override void Pause() { }

        //退出
        public override void Resume() { }
    }
}
