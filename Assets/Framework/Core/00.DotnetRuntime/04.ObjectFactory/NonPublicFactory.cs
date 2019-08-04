using System.Reflection;

namespace Framework
{
    /// <summary>
    /// 没有公共构造函数的工厂类
    /// </summary>
    public class NonPublicFactory<T> : IFactory<T> where T:class
    {
        public T Create()
        {
            return ReflectorUtility.CreateInstance<T>(BindingFlags.Instance | BindingFlags.NonPublic,null);
        }
    }
}
