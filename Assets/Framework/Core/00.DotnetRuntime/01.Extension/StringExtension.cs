
namespace Framework
{
    public static class StringExtension
    {
        
        /// <summary>
        /// 截取字符串左面
        /// </summary>
        /// <param name="self">数据源</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string Left(this string self, int length)
        {
            //返回非贪婪数据
            return Left(self, length, false);
        }

        /// <summary>
        /// 截取字符串左面
        /// </summary>
        /// <param name="self">数据源</param>
        /// <param name="length">截取长度</param>
        /// <param name="greedy">是否贪婪(true:标识截取长度超出字符串则返回剩余长度。false:返回空)</param>
        /// <returns></returns>
        public static string Left(this string self, int length, bool greedy)
        {
            string result = "";

            //如果不为空则
            if (!self.IsNullOrEmpty())
            {
                int len = self.Length;

                //如果大于截取长度则
                if (len > length)
                {
                    result = self.Substring(0, length);
                }
                else
                {
                    //greedy true:标识截取长度超出字符串则返回剩余长度。false:返回空
                    result = greedy ? self : "";
                }
            }
            else
            {
                result = "";
            }

            return result;
        }

        /// <summary>
        /// 截取字符串右面
        /// </summary>
        /// <param name="self">数据源</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string Right(this string self, int length)
        {
            //返回非贪婪数据
            return Right(self, length, false);
        }

        /// <summary>
        /// 截取字符串右面
        /// </summary>
        /// <param name="self">数据源</param>
        /// <param name="length">截取长度</param>
        /// <param name="greedy">是否贪婪(true:标识截取长度超出字符串则返回剩余长度。false:返回空)</param>
        /// <returns></returns>
        public static string Right(this string self, int length, bool greedy)
        {
            string result = "";

            //如果不为空则
            if (!self.IsNullOrEmpty())
            {
                int len = self.Length;

                //如果大于截取长度则
                if (len > length)
                {
                    result = self.Substring(len - length);
                }
                else
                {
                    //greedy true:标识截取长度超出字符串则返回剩余长度。false:返回空
                    result = greedy ? self : "";
                }
            }
            else
            {
                result = "";
            }

            return result;
        }

        /// <summary>
        /// 截取字符串中间
        /// </summary>
        /// <param name="self">数据源</param>
        /// <param name="startIndex">开始位置(从1开始)</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string Middle(this string self, int startIndex, int length)
        {
            //返回非贪婪数据
            return Middle(self, startIndex, length, false);
        }

        /// <summary>
        /// 截取字符串右面
        /// </summary>
        /// <param name="self">数据源</param>
        /// <param name="startIndex">开始位置()</param>
        /// <param name="length">截取长度</param>
        /// <param name="greedy">是否贪婪(true:标识截取长度超出字符串则返回剩余长度。false:返回空)</param>
        /// <returns></returns>
        public static string Middle(this string self, int startIndex, int length, bool greedy)
        {
            string result = "";

            //如果不为空则
            if (!self.IsNullOrEmpty())
            {
                int len = self.Length;

                //如果开始位置不正确,返回""
                if (startIndex < 1 || startIndex > len)
                {
                    result = "";
                }
                else
                {
                    //如果大于截取长度则
                    if (len - startIndex > length)
                    {
                        result = self.Substring((startIndex - 1), length);
                    }
                    else
                    {
                        //greedy true:标识截取长度超出字符串则返回剩余长度。false:返回空
                        result = greedy ? self : "";
                    }
                }
            }
            else
            {
                result = "";
            }

            return result;
        }
        
        /// <summary>
        /// 字符串、数值类型转枚举类型
        /// </summary>
        public static T ToEnum<T>(this string value)
        {
            return (T)System.Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] Split(this string self, string spliter)
        {
            string[] result = null;

            if (self.IsNotNullOrEmpty())
            {
                result = self.Split(spliter.ToCharArray()[0]);
            }

            return result;
        }
        
        /// <summary>
        /// 取得骆驼命名方式，首字母小写
        /// </summary>
        public static string ToCamel(this string self)
        {
            string result = "";

            //如果不为空则
            if (!self.IsNullOrEmpty())
            {
                result = self[0].ToString().ToLower() + self.Substring(1);
            }
            else
            {
                result = "";
            }
            
            return result;
        }
        
        /// <summary>
        /// 取得帕斯卡命名方式,首字母大写
        /// </summary>
        public static string ToPascal(this string self)
        {
            string result = "";

            //如果不为空则
            if (!self.IsNullOrEmpty())
            {
                result = self[0].ToString().ToUpper() + self.Substring(1);
            }
            else
            {
                result = "";
            }

            return result;
        }

        /// <summary>
        /// 转换为Unix行末字符 \r\n——> \n   \r——>\n
        /// </summary>
        public static string ToUnixLineEndings(this string str)
        {
            return str.Replace("\r\n", "\n").Replace("\r", "\n");
        }
        
        /// <summary>
        /// 是否存在中文字符
        /// </summary>
        public static bool HasChinese(this string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"[\u4e00-\u9fa5]");
        }

        /// <summary>
        /// 是否存在空格
        /// </summary>
        public static bool HasSpace(this string input)
        {
            return input.Contains(" ");
        }
    }
}
