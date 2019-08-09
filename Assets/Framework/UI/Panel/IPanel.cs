
namespace Framework.UI
{
    /// <summary>
    /// Panel接口
    /// </summary>
    public interface IPanel
    {
        //进入
        void Enter();

        //暂停
        void Pause();

        //恢复
        void Resume();

        //退出
        void Exit();
    }
}
