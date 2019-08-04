using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public static class SingletonProperty<T> where T:class, ISingleton
    {
        //定义内部静态变量
        private static T instance = null;

        //定义静态变量作为静态方法锁
        private static readonly object locker = new object();

        //单例方法暴露入口
        public static T Instance
        {
            get
            {
                //双重判定，避免锁消耗性能
                if (instance == null)
                {
                    lock (locker)
                    {
                        //锁后再判定，是为了防止实例已被其他线程生成
                        if (instance == null)
                        {
                            //泛型单例模式不能自身实例化，可以通过类型反射实例化对象。
                            instance = SingletonCreator.CreateInstance<T>();
                        }
                    }
                }

                return instance;
            }
        }

        //销毁对象
        public static void Dispose()
        {
            instance = null;
        }
    }
}
