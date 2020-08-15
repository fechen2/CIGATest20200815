using GameRisker.BasicLib.Singleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameRisker.BasicLib.Event
{
    /// <summary>
    /// 类与类之间的事件桥梁
    /// 请继承使用，根据自己定义的类型划分继承类，不建议一个类把所有事件通信都包揽
    /// </summary>
    public class ObjectEvent<T> : ISingler where T : IConvertible
    {
        class Execute
        {
            public void Send(List<OnEventDelegate> executes, T eventId, object data = null)
            {
                if (executes != null)
                {
                    List<OnEventDelegate> temps = new List<OnEventDelegate>();//<OnEventDelegate>.Get();

                    OnEventDelegate handler;
                    for (int i = 0; i < executes.Count; i++)
                    {
                        handler = executes[i];
                        temps.Add(handler);
                    }

                    while (temps.Count > 0)
                    {
                        handler = temps[0];
                        temps.RemoveAt(0);
                        try
                        {
#if UNITY_EDITOR
                                {
                                    handler(data);
                                }
#else
                                if (data != null) data.position = 0;
                                handler(data);
#endif
                        }
                        catch (Exception e)
                        {
                            UnityEngine.Debug.LogError("ObjectListenerEvent::Send " + e.Message + " EventID = " + eventId.ToString() + " ["+ e.StackTrace+ "]");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 事件处理回调函数
        /// </summary>
        /// <param name="varStore"></param>
        public delegate void OnEventDelegate(object value);

        private Dictionary<T, List<OnEventDelegate>> m_dic = new Dictionary<T, List<OnEventDelegate>>();

        /// <summary>
        /// 当前正在发送的事件Id  避免相同的事件叠加发送，导致死循环
        /// </summary>
        private int m_currentEventId;

        /// <summary>
        /// 增加广播监听
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="handler"></param>
		public void Add(T eventId, OnEventDelegate handler) 
        {
            if (handler == null)
            {
                //LogUtils.Error("ObjectListenerEvent::Add handler is null. eventId = ", eventId.ToString());
            }
            List<OnEventDelegate> list;
            if (m_dic.ContainsKey(eventId))
            {
                list = m_dic[eventId];
                list.Add(handler);
            }
            else
            {
                list = new List<OnEventDelegate>();
                list.Add(handler);
                m_dic[eventId] = list;
            }
        }

        /// <summary>
        /// 移除广播监听
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="handler"></param>
        public void Remove(T eventId, OnEventDelegate handler)
        {
            if (handler == null)
            {
                //LogUtils.Error("ObjectListenerEvent::Remove handler is null. eventId = ", eventId.ToString());
            }
            List<OnEventDelegate> list;
            if (m_dic.ContainsKey(eventId))
            {
                list = m_dic[eventId];
                list.Remove(handler);

                if (list.Count == 0)
                {
                    m_dic.Remove(eventId);
                }
            }
        }
        /// <summary>
        /// 移除事件所有监听
        /// </summary>
        /// <param name="eventId"></param>
        public void Clear(T eventId)
        {
            if (m_dic.ContainsKey(eventId))
            {
                m_dic.Remove(eventId);
            }
        }

        /// <summary>
        /// 发送广播
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="data"></param>
        public void Send(T eventId, object data = null)
        {
            //if (s_executes != null)
            {
                int evenId = eventId.ToInt32(null);
                if (m_currentEventId != evenId)
                {
                    List<OnEventDelegate> handles;
                    if (m_dic.TryGetValue(eventId, out handles))
                    {
                        m_currentEventId = evenId;
                        Execute execute = new Execute();
                        execute.Send(handles, eventId, data);
                        m_currentEventId = -1;
                    }
                }
                else
                {
                    //LogUtils.Error("ObjectEvent::Send the same eventId = ", eventId.ToString(), " cause an endless loop!");
                }
            }
        }

        public void Destroy()
        {
            m_dic.Clear();
            m_dic = null;
        }

        public void OnInit()
        {

        }
    }
}
