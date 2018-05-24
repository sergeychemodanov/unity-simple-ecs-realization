using System.Collections.Generic;
using System.Linq;

namespace SurvivalExample
{
    public class EntityManager
    {
        private readonly List<BaseEntity> _entities = new List<BaseEntity>();

        public List<BaseEntity> Entities { get { return _entities; }}

        public BaseEntity Create(List<BaseComponent> components = null)
        {
            var entity = new BaseEntity(components);
            _entities.Add(entity);

            return entity;
        }

        public BaseEntity Create(BaseComponent component)
        {
            var components = new List<BaseComponent> { component };
            return Create(components);
        }

        public void Destroy(BaseEntity entity)
        {
            foreach (var component in entity.Components)
                component.OnDestroy();

            _entities.Remove(entity);
        }
    }

    public static class EntityExtensions
    {
        public static List<BaseEntity> WithComponent<T>(this List<BaseEntity> entities)
        {
            return (from entity in entities
                    where entity.Components.Any(c => c is T)
                    select entity).ToList();
        }
    }
}