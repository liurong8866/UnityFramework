namespace Framework
{
    public enum JsonToolType
    {
        UnityJson,
        NewtonJson
    }

    public class JsonFactory
    {
        public static ISerializable Json(JsonToolType type = JsonToolType.NewtonJson)
        {
            ISerializable result;

            if (type == JsonToolType.NewtonJson)
                result = NewtonJson.Instance;
            else
                result = NewtonJson.Instance;

            return result;
        }
    }
}
