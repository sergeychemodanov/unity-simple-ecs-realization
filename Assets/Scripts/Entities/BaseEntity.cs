using System.Collections.Generic;
using System.Linq;

namespace SurvivalExample
{
    public class BaseEntity
    {
        public List<BaseComponent> Components { get; private set; }

        public BaseEntity(List<BaseComponent> components = null)
        {
            if (components == null)
            {
                Components = new List<BaseComponent>();
                return;
            }

            Components = components;
        }

        public BaseEntity AddComponent(BaseComponent component)
        {
            Components.Add(component);
            return this;
        }

        public BaseEntity RemoveComponent(BaseComponent component)
        {
            component.OnDestroy();
            Components.Remove(component);
            return this;
        }

        public BaseEntity RemoveComponents<T>()
        {
            var listToRemove = new List<BaseComponent>();

            var components = Components.Where(c => c is T);
            foreach (var component in components)
            {
                component.OnDestroy();
                listToRemove.Add(component);
            }

            foreach (var component in listToRemove)
                Components.Remove(component);

            return this;
        }

        public T GetComponent<T>() where T : BaseComponent
        {
            var component = Components.FirstOrDefault(c => c is T);
            return (T)component;
        }

        public List<T> GetComponents<T>() where T : BaseComponent
        {
            var components = Components.Where(c => c is T);
            return (List<T>)components;
        }
    }
}