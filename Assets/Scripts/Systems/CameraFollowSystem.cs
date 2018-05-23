using System.Linq;
using UnityEngine;

namespace SurvivalExample
{
    public class CameraFollowSystem : BaseSystem
    {
        private readonly Transform _playerTransform;
        private readonly Transform _cameraTransform;

        public CameraFollowSystem(EntityManager entityManager, EventManager eventManager)
        {
            var playerEntity = entityManager.Entities
                .WithComponent<PlayerHeroComponent>()
                .WithComponent<SceneObjectComponent>()
                .FirstOrDefault();

            if (playerEntity != null)
            {
                var playerSceneObjectComponent = playerEntity.GetComponent<SceneObjectComponent>();
                if (playerSceneObjectComponent != null)
                    _playerTransform = playerSceneObjectComponent.GameObject.transform;
            }

            var cameraEntity = entityManager.Entities
                .WithComponent<MainCameraComponent>()
                .WithComponent<SceneObjectComponent>()
                .FirstOrDefault();

            if (cameraEntity != null)
            {
                var cameraSceneObjectComponent = cameraEntity.GetComponent<SceneObjectComponent>();
                if (cameraSceneObjectComponent != null)
                    _cameraTransform = cameraSceneObjectComponent.GameObject.transform;
            }

            eventManager.Subscribe<PlayerMoveEvent>(OnPlayerMove);
        }

        private void OnPlayerMove(PlayerMoveEvent eventdata)
        {
            if (_playerTransform == null || _cameraTransform == null)
                return;

            _cameraTransform.position = _playerTransform.position;
        }
    }
}