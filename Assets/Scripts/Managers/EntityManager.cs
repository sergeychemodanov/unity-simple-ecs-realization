using System.Collections.Generic;
using System.Linq;

namespace SurvivalExample
{
    public class EntityManager : Singleton<EntityManager>
    {
        private readonly List<BaseEntity> _entities = new List<BaseEntity>();

        public static List<BaseEntity> Entities { get { return Instance._entities; }}

        public static BaseEntity Create(List<BaseComponent> components = null)
        {
            var entity = new BaseEntity(components);
            Instance._entities.Add(entity);

            return entity;
        }

        public static BaseEntity Create(BaseComponent component)
        {
            var components = new List<BaseComponent> { component };
            return Create(components);
        }

        public static void Destroy(BaseEntity entity)
        {
            var component = entity.Components.FirstOrDefault(c => c is SceneObjectComponent);
            if (component != null)
            {
                var sceneOjectComponent = (SceneObjectComponent)component;
                Destroy(sceneOjectComponent.GameObject);
            }

            Instance._entities.Remove(entity);
        }
    }
}