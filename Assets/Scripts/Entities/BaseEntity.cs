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
            Components.Remove(component);
            return this;
        }

        public T GetComponent<T>() where T : BaseComponent
        {
            var component = Components.FirstOrDefault(c => c is T);
            return (T) component;
        }
    }
}