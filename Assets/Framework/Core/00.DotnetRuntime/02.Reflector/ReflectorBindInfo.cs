using System.Reflection;

namespace Framework
{
    public class ReflectorBindInfo<T>
    {
        /// <summary>
        /// 绑定实例
        /// </summary>
        public T BindInstance { get; set; }

        /// <summary>
        /// 绑定事件
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 委托方法
        /// </summary>
        public string DelegateName { get; set; }

        /// <summary>
        /// 程序集
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 绑定类型
        /// </summary>
        public BindingFlags BindingFlag { get; set; }
    }
}