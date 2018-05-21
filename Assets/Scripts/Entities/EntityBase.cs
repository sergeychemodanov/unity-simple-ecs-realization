using System.Collections.Generic;

namespace SurvivalExample
{
    public class EntityBase : IEntity
    {
        public List<IComponent> Components { get; private set; }

        public EntityBase(List<IComponent> components)
        {
            Components = components;
        }
    }
}