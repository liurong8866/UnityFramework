using System;

namespace Framework
{
    /// <summary>
    /// 用于标记在Hierarchy中生成对象的路径
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MonoSingletonPath : Attribute
    {
        private string pathInHierarchy;

        public MonoSingletonPath(string pathInHierarchy)
        {
            this.pathInHierarchy = pathInHierarchy;
        }

        public string PathInHierarchy
        {
            get { return this.pathInHierarchy; }
        }
    }
}