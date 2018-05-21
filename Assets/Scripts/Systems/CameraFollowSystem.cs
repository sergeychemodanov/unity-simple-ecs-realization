using UnityEngine;

namespace SurvivalExample
{
    public class CameraFollowSystem : BaseSystem
    {
        private readonly Transform _playerTransform;
        private readonly Transform _cameraTransform;

        public CameraFollowSystem()
        {
            var playerEntity = EntityManager.GetFirstEntityWithComponent<IsPlayerComponent>();
            if (playerEntity != null)
            {
                var playerSceneObjectComponent = playerEntity.GetComponent<SceneObjectComponent>();
                if (playerSceneObjectComponent != null)
                    _playerTransform = playerSceneObjectComponent.GameObject.transform;
            }

            var cameraEntity = EntityManager.GetFirstEntityWithComponent<IsCameraComponent>();
            if (cameraEntity != null)
            {
                var cameraSceneObjectComponent = cameraEntity.GetComponent<SceneObjectComponent>();
                if (cameraSceneObjectComponent != null)
                    _cameraTransform = cameraSceneObjectComponent.GameObject.transform;
            }

            EventManager.Subscribe<PlayerMoveEvent>(OnPlayerMove);
        }

        private void OnPlayerMove(PlayerMoveEvent eventdata)
        {
            if (_playerTransform == null || _cameraTransform == null)
                return;

            _cameraTransform.position = _playerTransform.position;
        }
    }
}