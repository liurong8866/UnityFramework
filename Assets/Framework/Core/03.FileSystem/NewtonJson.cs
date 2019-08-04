using System;
using Newtonsoft.Json;

namespace Framework
{
    public class NewtonJson : Singleton<NewtonJson>, ISerializable
    {
        private NewtonJson() { }

        /// <summary>
        /// 序列化
        /// </summary>
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value);
        }
    }
}
