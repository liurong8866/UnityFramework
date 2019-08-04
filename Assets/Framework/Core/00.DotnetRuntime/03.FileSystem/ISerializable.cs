
namespace Framework
{
    public interface ISerializable : ISingleton
    {
        /// <summary>
        /// 序列化
        /// </summary>
        string Serialize(object obj);

        /// <summary>
        /// 反序列化
        /// </summary>
        T Deserialize<T>(string data);

        /// <summary>
        /// 反序列化
        /// </summary>
        object Deserialize(string data, System.Type type);
        
    }
}