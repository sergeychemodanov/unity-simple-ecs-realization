using UnityEngine;

namespace SurvivalExample
{
    public class PlayerMoveSystem : BaseSystem
    {
        private readonly SceneObjectComponent _playerSceneObjectComponent;
        private readonly MovementComponent _playerMovementComponent;


        public PlayerMoveSystem()
        {
            var playerEntity = EntityManager.GetFirstEntityWithComponent<IsPlayerComponent>();
            if (playerEntity != null)
            {
                _playerSceneObjectComponent = playerEntity.GetComponent<SceneObjectComponent>();
                _playerMovementComponent = playerEntity.GetComponent<MovementComponent>();
            }

            EventManager.Subscribe<PlayerMoveEvent>(OnPlayerMove);
        }


        private void OnPlayerMove(PlayerMoveEvent eventData)
        {
            if (_playerSceneObjectComponent == null)
                return;

            var playerTransform = _playerSceneObjectComponent.GameObject.transform;
            playerTransform.Translate(eventData.Direction * _playerMovementComponent.Speed * Time.deltaTime);
        }
    }
}