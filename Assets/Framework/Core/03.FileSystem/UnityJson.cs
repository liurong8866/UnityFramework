using System;
using UnityEngine;

namespace Framework
{
    public class UnityJson : Singleton<UnityJson>, ISerializable
    {
        private UnityJson() { }

        /// <summary>
        /// 序列化
        /// </summary>
        public string Serialize(object obj)
        {
            return JsonUtility.ToJson(obj);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public T Deserialize<T>(string data)
        {
            return JsonUtility.FromJson<T>(data);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public object Deserialize(string data, Type type)
        {
            return JsonUtility.FromJson(data, type);
        }
    }
}
