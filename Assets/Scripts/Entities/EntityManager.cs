using System.Collections.Generic;

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
}