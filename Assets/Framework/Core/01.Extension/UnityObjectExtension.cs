using UnityEngine;

namespace Framework
{
    public static class UnityObjectExtension
    {
        public static void Example()
        {
            var gameObject = new GameObject();

            gameObject.Instantiate()
                .Name("ExtensionExample")
                .DestroySelf();

            gameObject.Instantiate()
                .DestroySelfGracefully();

            gameObject.Instantiate()
                .DestroySelfAfterDelay(1.0f);

            gameObject.Instantiate()
                .DestroySelfAfterDelayGracefully(1.0f);

            gameObject
                .ApplySelfTo(selfObj => Debug.Log(selfObj.name))
                .Name("TestObj")
                .ApplySelfTo(selfObj => Debug.Log(selfObj.name))
                .Name("ExtensionExample")
                .DontDestroyOnLoad();
        }

        public static T Instantiate<T>(this T selfObj) where T : Object
        {
            return Object.Instantiate(selfObj);
        }

        public static T Name<T>(this T selfObj, string name) where T : Object
        {
            selfObj.name = name;
            return selfObj;
        }

        public static void DestroySelf<T>(this T selfObj) where T : Object
        {
            Object.Destroy(selfObj);
        }

        public static T DestroySelfGracefully<T>(this T selfObj) where T : Object
        {
            if (selfObj)
            {
                Object.Destroy(selfObj);
            }

            return selfObj;
        }

        public static T DestroySelfAfterDelay<T>(this T selfObj, float afterDelay) where T : Object
        {
            Object.Destroy(selfObj, afterDelay);
            return selfObj;
        }

        public static T DestroySelfAfterDelayGracefully<T>(this T selfObj, float delay) where T : Object
        {
            if (selfObj)
            {
                Object.Destroy(selfObj, delay);
            }

            return selfObj;
        }

        public static T ApplySelfTo<T>(this T selfObj, System.Action<T> toFunction) where T : Object
        {
            toFunction.InvokeGracefully(selfObj);
            return selfObj;
        }

        public static T DontDestroyOnLoad<T>(this T selfObj) where T : Object
        {
            Object.DontDestroyOnLoad(selfObj);
            return selfObj;
        }

        public static T As<T>(this Object selfObj) where T : Object
        {
            return selfObj as T;
        }

    }
}
