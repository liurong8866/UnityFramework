using System;

namespace Framework
{
    /// <summary>
    /// 用户自定义工厂类
    /// </summary>
    public class CustomFactory<T> : IFactory<T>
    {
        protected Func<T> creator;

        public CustomFactory(Func<T> creator)
        {
            this.creator = creator;
        }

        public T Create()
        {
            return creator();
        }
    }
}
