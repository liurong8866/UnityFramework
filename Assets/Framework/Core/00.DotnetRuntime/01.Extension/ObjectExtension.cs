using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 转换字符串
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToString(this object self)
        {
            return ToString(self, "");
        }

        /// <summary>
        /// 转换字符串
        /// </summary>
        /// <param name="self"></param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns></returns>
        public static string ToString(this object self, string defaultvalue)
        {
            string result = defaultvalue;

            if (!self.IsNullOrEmpty())
            {
                result = self.ToString();
            }

            return result;
        }

        /// <summary>
        /// 对象转换Short,如果对象为空，返回默认值
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static short ToShort(this object self)
        {
            short result;

            if (!self.IsNullOrEmpty())
            {
                bool parse = Int16.TryParse(self.ToString(), out result);

                if (parse != true)
                {
                    result = default(short);
                }
            }
            else
            {
                result = default(short);
            }

            return result;
        }

        /// <summary>
        /// 对象转换Int,如果对象为空，返回默认值
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int ToInt(this object self)
        {
            int result;

            if (!self.IsNullOrEmpty())
            {
                bool parse = Int32.TryParse(self.ToString(), out result);

                if (parse != true)
                {
                    result = default(int);
                }
            }
            else
            {
                result = default(int);
            }

            return result;
        }

        /// <summary>
        /// 对象转换Long,如果对象为空，返回默认值
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long ToLong(this object self)
        {
            long result;

            if (!self.IsNullOrEmpty())
            {
                bool parse = Int64.TryParse(self.ToString(), out result);

                if (parse != true)
                {
                    result = default(long);
                }
            }
            else
            {
                result = default(long);
            }

            return result;
        }

        /// <summary>
        /// 字符串转换Float,如果对象为空，返回默认值
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static float ToFloat(this object self)
        {
            float result;

            if (!self.IsNullOrEmpty())
            {
                bool parse = float.TryParse(self.ToString(), out result);

                if (parse != true)
                {
                    result = default(float);
                }
            }
            else
            {
                result = default(float);
            }

            return result;
        }

        /// <summary>
        /// 字符串转换Double,如果对象为空，返回默认值
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static double ToDouble(this object self)
        {
            double result;

            if (!self.IsNullOrEmpty())
            {
                bool parse = double.TryParse(self.ToString(), out result);

                if (parse != true)
                {
                    result = default(double);
                }
            }
            else
            {
                result = default(double);
            }

            return result;
        }

        /// <summary>
        /// 转换为DateTime型,如果对象为空，返回默认值 1970-1-1 00:00:01
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object self)
        {
            return ToDateTime(self, DateTime.Parse("1970-1-1 00:00:01"));
        }

        /// <summary>
        /// 转换为DateTime型,如果对象为空，返回defaultValue
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object self, DateTime defaultValue)
        {
            DateTime result;

            if (!self.IsNullOrEmpty())
            {
                bool parse = DateTime.TryParse(self.ToString(), out result);

                if (parse != true)
                {
                    result = defaultValue;
                }
            }
            else
            {
                result = defaultValue;
            }

            return result;
        }

        /// <summary>
        /// SQL 防止意外字符导致错误
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToSQLString(this object self)
        {
            string result;

            if (self == null)
            {
                result = "";
            }
            else
            {
                result = self.ToString().Trim().Replace("'", "''").Replace("]", "]]").Replace("%", "[%]").Replace("_", "[_]").Replace("^", "[^]");
            }

            return result;
        }

        /// <summary>
        /// SQL 防止意外字符导致错误
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToSQLString2(this object self)
        {
            string result;

            if (self == null)
            {
                result = "";
            }
            else
            {
                result = self.ToString().Trim().Replace("'", "’").Replace("]", "］").Replace("%", "％").Replace("_", "＿").Replace("^", "＾");
            }

            return result;
        }

        /// <summary>
        /// 是否为整型数值
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsInteger(this object self)
        {
            return (self is SByte || self is Int16 || self is Int32
                    || self is Int64 || self is Byte || self is UInt16
                    || self is UInt32 || self is UInt64);
        }

        /// <summary>
        /// 是否为浮点型
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsFloat(this object self)
        {
            return (self is float || self is double || self is Decimal);
        }

        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsNumeric(this object self)
        {
            if (!(self is Byte ||
                    self is Int16 ||
                    self is Int32 ||
                    self is Int64 ||
                    self is SByte ||
                    self is UInt16 ||
                    self is UInt32 ||
                    self is UInt64 ||
                    self is Decimal ||
                    self is Double ||
                    self is Single))
                return false;
            else
                return true;
        }

        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T Clone<T>(this T self)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制  
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, self);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }

    }
}
