using System;

namespace Framework
{
    public static class DotnetExtension
    {
        /// <summary>
        /// 打印字符串
        /// </summary>
        public static void Print<T>(this T self) where T : class
        {
            Console.WriteLine(self.IsNull() ? "" : self.ToString());
        }

        /// <summary>
        /// 判断是否为空
        /// <summary>
        public static bool IsNull<T>(this T self) where T : class
        {
            return self == null;
        }

        /// <summary>
        /// 判断不是为空
        /// </summary>
        public static bool IsNotNull<T>(this T self) where T : class
        {
            return self != null;
        }

        /// <summary>
        /// 判断是否为Null，并且字符串为""
        /// </summary>
        public static bool IsNullOrEmpty<T>(this T self) where T : class
        {
            return self == null ? true : String.IsNullOrEmpty(self.ToString());
        }

        /// <summary>
        /// 判断是否不为Null或""
        /// </summary>
        public static bool IsNotNullOrEmpty<T>(this T self) where T : class
        {
            return !self.IsNullOrEmpty();
        }

        /// <summary>
        /// 取得介于min与max范围内的值，如果不在范围内，取最近的值
        /// </summary>
        public static T Between<T>(this T self, T min, T max) where T : struct, IComparable<T>
        {
            T result = self;

            if (self.CompareTo(min) < 0)
            {
                result = min;
            }
            else if (self.CompareTo(max) > 0)
            {
                result = max;
            }

            return result;
        }

        /// <summary>
        /// 取得介于min与max范围内的值,如果不在范围内，取默认值
        /// </summary>
        public static T Between<T>(this T self, T min, T max, T defaultvalue) where T : struct, IComparable<T>
        {
            T result = self;

            if (self.CompareTo(min) < 0)
            {
                result = defaultvalue;
            }
            else if (self.CompareTo(max) > 0)
            {
                result = defaultvalue;
            }

            return result;
        }

        #region Func<T> Action<T> Delegate 扩展

        /// <summary>
        /// 功能：不为空则调用 Func
        /// </summary>
        public static T InvokeGracefully<T>(this Func<T> function)
        {
            return function != null ? function() : default(T);
        }

        /// <summary>
        /// 功能：不为空则调用 Action
        /// </summary>
        public static bool InvokeGracefully<T>(this Action action)
        {
            bool result = false;

            if (action != null)
            {
                action();
                result = true;
            }

            return result;
        }


        /// <summary>
        /// 不为空则调用 Action<T>
        /// </summary>
        public static bool InvokeGracefully<T>(this Action<T> action, T param)
        {
            bool result = false;

            if (action != null)
            {
                action(param);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 不为空则调用 Action<T>
        /// </summary>
        public static bool InvokeGracefully<T, K>(this Action<T, K> action, T param1, K param2)
        {
            bool result = false;

            if (action != null)
            {
                action(param1, param2);
                result = true;
            }

            return result;
        }
        
        /// <summary>
        /// 功能：不为空则调用 Delegate
        /// </summary>
        public static bool InvokeGracefully<T>(this Delegate action, params object[] param)
        {
            bool result = false;

            if (action != null)
            {
                action.DynamicInvoke(param);
                result = true;
            }

            return result;
        }

        #endregion
    }
}
