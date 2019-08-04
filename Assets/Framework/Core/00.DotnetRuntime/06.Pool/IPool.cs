
namespace Framework
{
    /// <summary>
    /// 对象池接口
    /// </summary>
    public interface IPool<T> where T:class
    {
        /// <summary>
        /// 当前缓存对象的数量
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 分配对象
        /// </summary>
        T Allocate();

        /// <summary>
        /// 回收对象
        /// </summary>
        bool Recycle(T instance);
    }
}
