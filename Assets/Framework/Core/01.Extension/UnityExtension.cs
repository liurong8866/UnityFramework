using UnityEngine;

namespace Framework
{
    public static class BehaviourExtension
    {
        /// <summary>
        /// 打印字符串
        /// </summary>
        public static void Log<T>(this T self) where T : class
        {
            Debug.Log(self.IsNullOrEmpty() ? "" : self.ToString());
        }

        public static T Enable<T>(this T selfBehaviour) where T : Behaviour
        {
            selfBehaviour.enabled = true;
            return selfBehaviour;
        }

        public static T Disable<T>(this T selfBehaviour) where T : Behaviour
        {
            selfBehaviour.enabled = false;
            return selfBehaviour;
        }
    }

    



}