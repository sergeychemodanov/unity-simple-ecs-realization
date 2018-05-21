using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SurvivalExample
{
    public class EntityManager : Singleton<EntityManager>
    {
        private readonly List<IEntity> _entities = new List<IEntity>();

        public static List<IEntity> GetEntitiesWithComponent<T>() where T : IComponent
        {
            var entities = (
                from entity in Instance._entities
                let isComponentExist = entity.Components.Exists(c => c.GetType() == typeof(T))
                where isComponentExist select entity
            ).ToList();

            return entities;
        }

        public static IEntity Create(List<IComponent> components)
        {
            var component = components.FirstOrDefault(c => c is SceneObjectComponent);
            if (component != null)
            {
                var sceneOjectComponent = (SceneObjectComponent)component;
                var prefab = Resources.Load<GameObject>(sceneOjectComponent.ResourcePath);
                var go = Instantiate(prefab);
                sceneOjectComponent.GameObject = go;
            }

            var entity = new EntityBase(components);
            Instance._entities.Add(entity);

            return entity;
        }

        public static void Destroy(IEntity entity)
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