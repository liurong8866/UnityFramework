
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Framework
{
    /// <summary>
    /// UI事件监听
    /// </summary>
    public class UIEvent: Singleton<UIEvent>
    {
        private UIEvent() {}

        public delegate void OnEvent(BaseEventData pd);

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="gameObject">监听事件的对象</param>
        /// <param name="eventType">监听事件类型</param>
        /// <param name="callback">回调方法</param>
        public void BindEvent(GameObject gameObject, EventTriggerType eventType, OnEvent callback)
        {

            //1.给需要的物体添加事件的组件EventerTrigger
            EventTrigger trigger = gameObject.GetComponent<EventTrigger>();

            if (trigger == null)
            {
                trigger = gameObject.AddComponent<EventTrigger>();
            }

            //2.初始化EventTrigger.Entry容器
            if (trigger.triggers.Count == 0)
            {
                trigger.triggers = new List<EventTrigger.Entry>();
            }

            //3.传入一个要调用的方法名称
            UnityAction<BaseEventData> action = new UnityAction<BaseEventData>(callback);

            //4.实例化一个EventTrigger.Entry对象
            EventTrigger.Entry enter = new EventTrigger.Entry();

            //5.指定事件触发的类型
            enter.eventID = eventType;

            //6.添加
            enter.callback.AddListener(action);

            //7.添加
            trigger.triggers.Add(enter);
        }

    }
}