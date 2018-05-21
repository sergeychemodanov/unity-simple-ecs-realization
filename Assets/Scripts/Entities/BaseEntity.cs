using System.Collections.Generic;
using System.Linq;

namespace SurvivalExample
{
    public class BaseEntity
    {
        public List<BaseComponent> Components { get; private set; }

        public BaseEntity(List<BaseComponent> components)
        {
            Components = components;
        }

        public T GetComponent<T>() where T : BaseComponent
        {
            var component = Components.FirstOrDefault(c => c is T);
            return (T) component;
        }
    }
}