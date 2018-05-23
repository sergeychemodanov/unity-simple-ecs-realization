using UnityEngine;

namespace SurvivalExample
{
    public class GameController : MonoBehaviour
    {
        private readonly EntityManager _entityManager = new EntityManager();
        private readonly EventManager _eventManager = new EventManager();
        private BaseSystem[] _systems;

        private void Start()
        {
            _systems = new BaseSystem[]
            {
#if UNITY_STANDALONE || UNITY_EDITOR
                new StandaloneInputSystem(_eventManager),
#elif UNITY_ANDROID || UNITY_IOS
// TODO create mobile input system
#endif

                new CreateCamerasSystem(_entityManager),
                new CreateLevelSystem(_entityManager),
                new CreatePlayerHeroSystem(_entityManager),

                new PlayerMoveSystem(_entityManager, _eventManager),
                new CameraFollowSystem(_entityManager, _eventManager),
            };
        }

        private void Update()
        {
            foreach (var system in _systems)
                system.Update();
        }
    }
}