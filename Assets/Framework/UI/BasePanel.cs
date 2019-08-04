
namespace Framework.UI
{
    public abstract class BasePanel : IPanel
    {
        public abstract void Enter();

        public abstract void Exit();

        public abstract void Pause();

        public abstract void Resume();
    }
}
