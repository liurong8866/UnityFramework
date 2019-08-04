using System.Collections.Generic;

namespace Framework
{
    /// <summary>
    /// 对象池抽象类
    /// </summary>
    public abstract class Pool<T> : IPool<T> where T : class
    {
        protected readonly Stack<T> pool = new Stack<T>();

        // 分配
        public virtual T Allocate()
        {
            //如果对象池中没有对象，则创建，如果有，则取出来分配
            return pool.Count == 0 ? Factory.Create() : pool.Pop();
        }

        //回收
        public abstract bool Recycle(T obj);
        
        //当前数量
        public int Count { get { return pool.Count; } }

        //对象工厂
        protected abstract IFactory<T> Factory { get; }
    }
}
