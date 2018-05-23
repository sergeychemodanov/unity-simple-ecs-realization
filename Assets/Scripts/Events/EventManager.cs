using System;
using System.Collections.Generic;

namespace SurvivalExample
{
    public class EventManager
    {
        private readonly Dictionary<Type, Delegate> _events = new Dictionary<Type, Delegate>();

        public void Subscribe<T>(EventHandler<T> eventHandler)
        {
            if (eventHandler == null)
                return;

            var eventType = typeof(T);
            Delegate handlers;
            _events.TryGetValue(eventType, out handlers);
            _events[eventType] = (handlers as EventHandler<T>) + eventHandler;
        }

        public void Unsubscribe<T>(EventHandler<T> eventHandler)
        {
            if (eventHandler == null)
                return;

            var eventType = typeof(T);
            Delegate handlers;
            if (!_events.TryGetValue(eventType, out handlers))
                return;

            var list = (handlers as EventHandler<T>) - eventHandler;
            if (list == null)
                _events.Remove(eventType);
        }

        public void Publish<T>(T eventMessage)
        {
            var eventType = typeof(T);
            Delegate rawList;
            _events.TryGetValue(eventType, out rawList);
            var list = rawList as EventHandler<T>;
            if (list == null)
                return;

            list(eventMessage);
        }
    }

    public delegate void EventHandler<T>(T eventData);
}