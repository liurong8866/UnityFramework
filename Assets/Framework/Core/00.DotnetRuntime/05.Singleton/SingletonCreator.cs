
using System.Reflection;


namespace Framework
{
    public class SingletonCreator
    {
        public static T CreateInstance<T>() where T : class, ISingleton
        {
            //通过反射创建实例化对象。 
            T instance = ReflectorUtility.CreateInstance<T>(BindingFlags.Instance | BindingFlags.NonPublic, null);

            instance.OnInit();

            return instance;
        }
    }
}