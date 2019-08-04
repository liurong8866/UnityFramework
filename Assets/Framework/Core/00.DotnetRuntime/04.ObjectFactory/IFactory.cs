

namespace Framework
{
    /// <summary>
    /// 定义工厂接口
    /// </summary>
    public interface IFactory<T>
    {
        T Create();
    }
}
