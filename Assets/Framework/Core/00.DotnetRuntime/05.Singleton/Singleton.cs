
namespace Framework
{
    /// <summary>
    /// 支持泛型的单例，继承自此类，均为单例模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> : ISingleton where T: Singleton<T>
    {
        //定义内部静态变量
        private static T instance = null;

        //定义静态变量作为静态方法锁
        private static readonly object locker = new object();

        //受保护构造函数，子类可继承
        protected Singleton() { }

        //单例方法暴露入口
        public static T Instance
        {
            get
            {
                //双重判定，避免锁消耗性能
                if(instance == null)
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

        //当单例模式初始化时调用
        public virtual void OnInit() { }

        //销毁对象
        public virtual void Dispose()
        {
            instance = null;
        }
    }
}
