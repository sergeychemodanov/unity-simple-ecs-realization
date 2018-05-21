using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SurvivalExample
{
    public class EntityManager : Singleton<EntityManager>
    {
        private readonly List<BaseEntity> _entities = new List<BaseEntity>();

        public static List<BaseEntity> GetEntitiesWithComponent<T>() where T : BaseComponent
        {
            var entities = (
                from entity in Instance._entities
                let isComponentExist = entity.Components.Exists(c => c is T)
                where isComponentExist
                select entity
            ).ToList();

            return entities;
        }

        public static BaseEntity GetFirstEntityWithComponent<T>() where T : BaseComponent
        {
            return GetEntitiesWithComponent<T>().FirstOrDefault();
        }

        public static BaseEntity Create(List<BaseComponent> components)
        {
            var component = components.FirstOrDefault(c => c is SceneObjectComponent);
            if (component != null)
            {
                var sceneOjectComponent = (SceneObjectComponent)component;
                var prefab = Resources.Load<GameObject>(sceneOjectComponent.ResourcePath);
                var go = Instantiate(prefab);
                sceneOjectComponent.SetGameObject(go);
            }

            var entity = new BaseEntity(components);
            Instance._entities.Add(entity);

            return entity;
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