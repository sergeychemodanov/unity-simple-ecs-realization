using System;
using System.Collections.Generic;

namespace SurvivalExample
{
    public class EventManager : Singleton<EventManager>
    {
        private readonly Dictionary<Type, Delegate> _events = new Dictionary<Type, Delegate>();

        public static void Subscribe<T>(EventHandler<T> eventHandler)
        {
            if (eventHandler == null)
                return;

            var eventType = typeof(T);
            Delegate handlers;
            Instance._events.TryGetValue(eventType, out handlers);
            Instance._events[eventType] = (handlers as EventHandler<T>) + eventHandler;
        }

        public static void Unsubscribe<T>(EventHandler<T> eventHandler)
        {
            if (eventHandler == null)
                return;

            var eventType = typeof(T);
            Delegate handlers;
            if (!Instance._events.TryGetValue(eventType, out handlers))
                return;

            var list = (handlers as EventHandler<T>) - eventHandler;
            if (list == null)
                Instance._events.Remove(eventType);
        }

        public static void Publish<T>(T eventMessage)
        {
            var eventType = typeof(T);
            Delegate rawList;
            Instance._events.TryGetValue(eventType, out rawList);
            var list = rawList as EventHandler<T>;
            if (list == null)
                return;

            list(eventMessage);
        }
    }

    public delegate void EventHandler<T>(T eventData);
}