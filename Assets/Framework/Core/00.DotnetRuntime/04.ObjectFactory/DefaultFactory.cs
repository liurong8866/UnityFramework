
namespace Framework
{
    /// <summary>
    /// 默认工厂类
    /// </summary>
    public class DefaultFactory<T> : IFactory<T> where T:new()
    {
        public T Create()
        {
            return new T();
        }
    }
}
