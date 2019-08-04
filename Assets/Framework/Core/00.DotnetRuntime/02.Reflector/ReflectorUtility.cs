using System;
using System.Reflection;

namespace Framework
{
    public class ReflectorUtility
    {
        /// <summary>
        /// 动态绑定事件
        /// </summary>
        /// <typeparam name="T">绑定方法类型</typeparam>
        /// <typeparam name="D">绑定委托类型</typeparam>
        /// <param name="bindInfo">绑定信息</param>
        public static Delegate DynamicDelegate<T, D>(string methodName, BindingFlags bindFlag)
            where T : class, new()
            where D : class
        {
            Delegate d = null;

            MethodInfo method = typeof(T).GetMethod(methodName, bindFlag);

            if ((bindFlag & BindingFlags.Static) == BindingFlags.Static)
            {
                d = Delegate.CreateDelegate(typeof(D), method);
            }
            else
            {
                T bindInstance = new T();

                d = Delegate.CreateDelegate(typeof(D), bindInstance, method, false);
            }
            return d;
        }

        /// <summary>
        /// 动态绑定事件
        /// </summary>
        /// <typeparam name="D">绑定委托类型</typeparam>
        /// <param name="bindInfo">绑定信息</param>
        public static Delegate DynamicDelegate<D>(string nameSpace, string className, string methodName, BindingFlags bindFlag)
            where D : class
        {
            Delegate d = null;

            //获取方法
            Type type = Type.GetType(nameSpace + "." + className);

            MethodInfo method = type.GetMethod(methodName, bindFlag);

            if ((bindFlag & BindingFlags.Static) == BindingFlags.Static)
            {
                d = Delegate.CreateDelegate(typeof(D), method);
            }
            else
            {
                //创建方法
                object bindInstance = Activator.CreateInstance(type);

                d = Delegate.CreateDelegate(typeof(D), bindInstance, method, false);
            }
            return d;
        }

        /// <summary>
        /// 动态绑定事件
        /// </summary>
        /// <typeparam name="D">绑定委托类型</typeparam>
        /// <param name="bindInfo">绑定信息</param>
        public static Delegate DynamicDelegate<D>(string assemblyName, string nameSpace, string className, string methodName, BindingFlags bindFlag)
            where D : class
        {
            Delegate d = null;

            //取得程序集
            Assembly assembly = Assembly.Load(assemblyName);

            //获取方法
            Type type = Type.GetType(nameSpace + "." + className);

            MethodInfo method = type.GetMethod(methodName, bindFlag);

            if ((bindFlag & BindingFlags.Static) == BindingFlags.Static)
            {
                d = Delegate.CreateDelegate(typeof(D), method);
            }
            else
            {
                //创建方法
                object bindInstance = Activator.CreateInstance(type);

                d = Delegate.CreateDelegate(typeof(D), bindInstance, method, false);
            }
            return d;
        }

        /// <summary>
        /// 动态绑定事件
        /// </summary>
        /// <typeparam name="T">绑定对象类型</typeparam>
        /// <typeparam name="D">绑定委托类型</typeparam>
        /// <typeparam name="B">绑定方法类型</typeparam>
        /// <param name="bindInfo">绑定信息</param>
        public static void DynamicDelegateBind<T, D, B>(ReflectorBindInfo<T> bindInfo)
            where T : class
            where D : class
            where B : class, new()
        {
            //取得代理方法
            D d = DynamicDelegate<B, D>(bindInfo.MethodName, bindInfo.BindingFlag) as D;

            //取得需赋值方法
            FieldInfo fieldInfo = bindInfo.BindInstance.GetType().GetField(bindInfo.DelegateName);

            fieldInfo.SetValue(bindInfo.BindInstance, d);
        }

        /// <summary>
        /// 动态绑定事件
        /// </summary>
        /// <typeparam name="T">绑定对象类型</typeparam>
        /// <typeparam name="D">绑定委托类型</typeparam>
        /// <typeparam name="B">绑定方法类型</typeparam>
        /// <param name="bindInfo">绑定信息</param>
        public static void DynamicDelegateBind<T, D>(ReflectorBindInfo<T> bindInfo)
            where T : class
            where D : class
        {

            //取得代理方法
            D d = DynamicDelegate<D>(bindInfo.AssemblyName, bindInfo.NameSpace, bindInfo.ClassName, bindInfo.MethodName, bindInfo.BindingFlag) as D;

            //取得需赋值方法
            FieldInfo fieldInfo = bindInfo.BindInstance.GetType().GetField(bindInfo.DelegateName);

            fieldInfo.SetValue(bindInfo.BindInstance, d);
        }

        /// <summary>
        /// 动态绑定事件
        /// </summary>
        /// <typeparam name="T">绑定对象类型</typeparam>
        /// <typeparam name="D">绑定委托类型</typeparam>
        /// <typeparam name="B">绑定方法类型</typeparam>
        /// <param name="bindInfo">绑定信息</param>
        public static void DynamicEventBind<T, D, B>(ReflectorBindInfo<T> bindInfo)
            where T : class
            where D : class
            where B : class
        {
            D d = null;

            //获取需绑定对象的事件
            EventInfo eventInfo = bindInfo.BindInstance.GetType().GetEvent(bindInfo.EventName);

            //获取事件类型
            Type type = eventInfo.EventHandlerType;

            //方法
            MethodInfo method = typeof(B).GetMethod(bindInfo.MethodName, bindInfo.BindingFlag);

            if ((bindInfo.BindingFlag & BindingFlags.Static) == BindingFlags.Static)
            {
                d = Delegate.CreateDelegate(type, method) as D;
            }
            else
            {
                B bindInstance = default(B);

                d = Delegate.CreateDelegate(typeof(D), bindInstance, method, false) as D;
            }

            MethodInfo miAddHandler = eventInfo.GetAddMethod();

            object[] addHandlerArgs = { d };

            miAddHandler.Invoke(bindInfo.BindInstance, addHandlerArgs);

        }


        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullName">命名空间.类型名</param>
        /// <param name="assemblyName">程序集</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string fullName, string assemblyName)
        {
            try
            {
                string path = fullName + "," + assemblyName;//命名空间.类型名,程序集

                Type o = Type.GetType(path);//加载类型

                object instance = Activator.CreateInstance(o, true);//根据类型创建实例

                return (T)instance;//类型转换并返回
            }
            catch
            {
                //发生异常，返回类型的默认值
                return default(T);
            }
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="assemblyName">类型所在程序集名称</param>
        /// <param name="nameSpace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assemblyName, string nameSpace, string className)
        {
            try
            {
                string fullName = nameSpace + "." + className;//命名空间.类型名
                                                              //此为第一种写法
                object instance = Assembly.Load(assemblyName).CreateInstance(fullName);//加载程序集，创建程序集里面的 命名空间.类型名 实例
                return (T)instance;//类型转换并返回
            }
            catch
            {
                //发生异常，返回类型的默认值
                return default(T);
            }
        }

        /// <summary>
        /// 创建对象实例，构造函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bindingFlags"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(BindingFlags bindingFlags, object[] parameters)
        {
            // 获取私有构造函数
            var ctors = typeof(T).GetConstructors(bindingFlags);

            // 获取无参构造函数
            var ctor = Array.Find(ctors, c => c.GetParameters().Length == (parameters == null ? 0 : parameters.Length));

            if (ctor != null)
            {
                // 通过构造函数，常见实例
                var retInstance = (T)ctor.Invoke(parameters);

                return retInstance;
            }
            else
            {
                return default(T);
            }
        }
    }
}