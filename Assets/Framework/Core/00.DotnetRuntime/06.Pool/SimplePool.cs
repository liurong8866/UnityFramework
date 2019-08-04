using System;

namespace Framework
{
    /// <summary>
    /// 简单对象池
    /// </summary>
    public class SimplePool<T> : Pool<T> where T : class, IPoolable
    {
        private IFactory<T> factory = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="creator">使用对象池类的创建方法</param>
        /// <param name="count"></param>
        public SimplePool(Func<T> creator, int count = 0)
        {
            this.factory = new CustomFactory<T>(creator);

            //初始化对象池
            InitPool(count);
        }

        /// <summary>
        /// 初始化对象池
        /// </summary>
        private void InitPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                pool.Push(this.factory.Create());
            }
        }
        
        /// <summary>
        /// 返回工厂方法
        /// </summary>
        protected override IFactory<T> Factory { get { return this.factory; } }

        /// <summary>
        /// 回收对象
        /// </summary>
        public override bool Recycle(T instance)
        {
            bool result = false;

            if (instance.IsNotNull())
            {
                //对象回收前的处理
                instance.OnRecycle();
                
                //回收到栈内
                pool.Push(instance);

                result = true;

            }
            return result;
        }
    }
}
