using System;
using System.Collections.Generic;

namespace Framework
{

    //事件接口
    public delegate void OnEvent(int key, params object[] param);


    public class EventSystem : Singleton<EventSystem>, IPoolable
    {
        private readonly Dictionary<int, ListenerMap> listenerMap = new Dictionary<int, ListenerMap>(50);

        public bool IsRecycled { get; set; }

        private EventSystem() { }

        #region 功能函数

        public bool Register<T>(T key, OnEvent fun) where T : IConvertible
        {
            var kv = key.ToInt32(null);

            ListenerMap mapper;            
            if (!listenerMap.TryGetValue(kv, out mapper))
            {
                mapper = new ListenerMap();
                listenerMap.Add(kv, mapper);
            }

            if (mapper.Add(fun))
            {
                return true;
            }

            ("Already Register Same Event:" + key).Print();
            return false;
        }

        public void UnRegister<T>(T key, OnEvent fun) where T : IConvertible
        {
            ListenerMap mapper;
            if (listenerMap.TryGetValue(key.ToInt32(null), out mapper))
            {
                mapper.Remove(fun);
            }
        }

        public void UnRegister<T>(T key) where T : IConvertible
        {
            ListenerMap mapper;
            if (listenerMap.TryGetValue(key.ToInt32(null), out mapper))
            {
                mapper.RemoveAll();
                mapper = null;

                listenerMap.Remove(key.ToInt32(null));
            }
        }

        public bool Send<T>(T key, params object[] param) where T : IConvertible
        {
            int kv = key.ToInt32(null);
            ListenerMap mapper;
            if (listenerMap.TryGetValue(kv, out mapper))
            {
                return mapper.Fire(kv, param);
            }
            return false;
        }

        public void OnRecycle()
        {
            listenerMap.Clear();
        }

        #endregion

        #region 高频率使用的API
        public static bool SendEvent<T>(T key, params object[] param) where T : IConvertible
        {
            return Instance.Send(key, param);
        }

        public static bool RegisterEvent<T>(T key, OnEvent fun) where T : IConvertible
        {
            return Instance.Register(key, fun);
        }

        public static void UnRegisterEvent<T>(T key, OnEvent fun) where T : IConvertible
        {
            Instance.UnRegister(key, fun);
        }
        #endregion

        #region 内部类

        private class ListenerMap
        {
            private LinkedList<OnEvent> eventList;

            public bool Fire(int key, params object[] param)
            {
                if (eventList == null)
                {
                    return false;
                }

                var next = eventList.First;
                OnEvent call = null;
                LinkedListNode<OnEvent> nextCache = null;

                while (next != null)
                {
                    call = next.Value;
                    nextCache = next.Next;
                    call(key, param);

                    next = next.Next ?? nextCache;
                }

                return true;
            }

            public bool Add(OnEvent listener)
            {
                if (eventList == null)
                {
                    eventList = new LinkedList<OnEvent>();
                }

                if (eventList.Contains(listener))
                {
                    return false;
                }

                eventList.AddLast(listener);
                return true;
            }

            public void Remove(OnEvent listener)
            {
                if (eventList == null)
                {
                    return;
                }

                eventList.Remove(listener);
            }

            public void RemoveAll()
            {
                if (eventList == null)
                {
                    return;
                }

                eventList.Clear();
            }
        }

        #endregion

    }
}