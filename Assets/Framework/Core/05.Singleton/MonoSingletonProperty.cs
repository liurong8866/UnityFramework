using UnityEngine;

namespace Framework
{
    public static class MonoSingletonProperty<T> where T: MonoBehaviour, ISingleton
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
                            instance = MonoSingletonCreator.CreateMonoInstance<T>();
                        }
                    }
                }

                return instance;
            }
        }


        public static void Dispose()
        {
            Object.Destroy(instance.gameObject);
        }

    }
}
