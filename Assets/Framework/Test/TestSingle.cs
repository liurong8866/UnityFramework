
using System.Reflection;
using UnityEngine;

namespace Framework
{
    public class TestSingle : MonoSingleton<TestSingle>
    {
        // Start is called before the first frame update
        private void Start()
        {
            //Singleton 例子
            XXXManager.Instance.XXXYYYZZZ();


            //自身MonoSingleton 例子
            TestSingle.Instance.print();

            //其他类MonoSingleton 例子
            UserInfo.Instance.name.Print();


            UserInfo user = ReflectorUtility.CreateInstance<UserInfo>(BindingFlags.Public | BindingFlags.Instance, new object[] { "liurong", 18 });

            Debug.Log(user.name);

        }

        public void print()
        {
            Debug.Log("XXXYYYZZZ");
        }

        /// <summary>
        /// 1.需要继承 Singleton。
        /// 2.需要实现非 public 的构造方法。
        /// </summary>
        private class XXXManager : Singleton<XXXManager>
        {
            private XXXManager()
            {
                // to do ...
            }

            public void XXXYYYZZZ()
            {
                Debug.Log("XXXYYYZZZ");
            }

            public string Name { get; set; }
        }

    }



    [MonoSingletonPath("Root/UI/Login")]
    public class UserInfo : MonoSingleton<UserInfo>
    {
        public string username;
        int age;

        public UserInfo(string name, int age)
        {
            this.username = name;
            this.age = age;
        }

        public override string ToString()
        {
            return name + age.ToString();
        }
    }
}