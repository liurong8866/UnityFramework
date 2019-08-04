using System.Reflection;

using UnityEngine;

namespace Framework
{
    public class MonoSingletonCreator
    {
        public static T CreateMonoInstance<T>() where T : MonoBehaviour, ISingleton
        {
            T instance = null;

            //如果游戏未运行，退出
            if (!Application.isPlaying) return instance;

            //如果在Hierarchy面板找到此类型，则返回该值并退出
            instance = UnityEngine.Object.FindObjectOfType<T>();
            if (instance != null)
            {
                instance.OnInit();
                return instance;
            }

            //如果未在Hierarchy面板找到，则查看是否该类型有 PathInHierarchy 特性，根据特性路径创建到Hierarchy中
            MemberInfo info = typeof(T);
            var attributes = info.GetCustomAttributes(true);

            foreach (var atribute in attributes)
            {
                MonoSingletonPath path = atribute as MonoSingletonPath;
                if (path != null)
                {
                    instance = CreateComponentOnGameObject<T>(path.PathInHierarchy, true);
                    break;
                }
            }

            //如果仍然为null，尝试用 new GameObject(name) 方式创建空对象，并命名为name
            if (instance == null)
            {
                var obj = new GameObject(typeof(T).Name);
                UnityEngine.Object.DontDestroyOnLoad(obj);
                instance = obj.AddComponent<T>();
            }

            instance.OnInit();
            return instance;
        }

        private static T CreateComponentOnGameObject<T>(string path, bool dontDestroy) where T : MonoBehaviour
        {
            var obj = FindGameObject(path, true, dontDestroy);
            if (obj == null)
            {
                obj = new GameObject("Singleton of " + typeof(T).Name);
                if (dontDestroy)
                {
                    UnityEngine.Object.DontDestroyOnLoad(obj);
                }
            }

            return obj.AddComponent<T>();
        }

        private static GameObject FindGameObject(string path, bool build, bool dontDestroy)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            var subPath = path.Split('/');
            if (subPath == null || subPath.Length == 0)
            {
                return null;
            }

            return FindGameObject(null, subPath, 0, build, dontDestroy);
        }

        private static GameObject FindGameObject(GameObject root, string[] subPath, int index, bool build, bool dontDestroy)
        {
            GameObject client = null;

            if (root == null)
            {
                client = GameObject.Find(subPath[index]);
            }
            else
            {
                var child = root.transform.Find(subPath[index]);
                if (child != null)
                {
                    client = child.gameObject;
                }
            }

            if (client == null)
            {
                if (build)
                {
                    client = new GameObject(subPath[index]);
                    if (root != null)
                    {
                        client.transform.SetParent(root.transform);
                    }

                    if (dontDestroy && index == 0)
                    {
                        GameObject.DontDestroyOnLoad(client);
                    }
                }
            }

            if (client == null)
            {
                return null;
            }

            return ++index == subPath.Length ? client : FindGameObject(client, subPath, index, build, dontDestroy);
        }

    }
}
