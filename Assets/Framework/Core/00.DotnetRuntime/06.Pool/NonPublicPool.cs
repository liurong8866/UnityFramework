using System;

namespace Framework
{
    public class NonPublicPool<T> : Pool<T>, ISingleton where T : class, IPoolable
    {
        private IFactory<T> factory = null;

        private int maxsize;

        #region 单例模式
        protected NonPublicPool() { factory = new NonPublicFactory<T>(); }

        public static NonPublicPool<T> Instance
        {
            get { return SingletonProperty<NonPublicPool<T>>.Instance; }
        }

        public void Dispose()
        {
            SingletonProperty<NonPublicPool<T>>.Dispose();
        }

        public void OnSingletonInit() { }

        #endregion

        /// <summary>
        /// 初始化对象池
        /// </summary>
        /// <param name="count">对象池容量</param>
        public void InitPool(int size)
        {
            if (size < 1) throw new Exception($"对象池容量不能小于1，初始化对象池报错。size={size}, class ={typeof(T)}");

            this.maxsize = size;

            for (int i = 0; i < size; i++)
            {
                pool.Push(this.factory.Create());
            }
        }

        /// <summary>
        /// 重新设置对象池大小
        /// </summary>
        /// <param name="count">对象池容量</param>
        public void Resize(int size)
        {
            if (size < 1) throw new Exception($"对象池容量不能小于1，重新设置对象池大小报错。size={size}, class ={typeof(T)}");

            //更新最大值
            this.maxsize = size;

            //获取当前数量，因为this.Count是动态算出来的
            int currentCount = this.Count;

            //如果当前数量多，则减去
            if (currentCount > this.maxsize)
            {
                for (int i = 0; i < currentCount - this.maxsize; i++)
                {
                    pool.Pop();
                }
            }
            //如果当前数量少，则补满
            else if (currentCount < size)
            {
                for (int i = 0; i < this.maxsize - currentCount; i++)
                {
                    pool.Push(this.factory.Create());
                }
            }
        }

        /// <summary>
		/// 分配对象
		/// </summary>
		public override T Allocate()
        {
            var result = base.Allocate();

            result.IsRecycled = false;

            return result;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        public override bool Recycle(T instance)
        {
            bool result = false;

            if (instance.IsNotNull() && !instance.IsRecycled)
            {
                //对象回收前的处理
                instance.OnRecycle();

                if (this.Count < this.maxsize)
                {
                    //回收到栈内
                    pool.Push(instance);

                    instance.IsRecycled = true;

                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 返回工厂方法
        /// </summary>
        protected override IFactory<T> Factory { get { return this.factory; } }

    }
}
