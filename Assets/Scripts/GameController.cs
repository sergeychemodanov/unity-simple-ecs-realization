using UnityEngine;

namespace SurvivalExample
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Configs _configs;

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

                new CamerasInitializeSystem(_entityManager, _configs),
                new LevelInitializeSystem(_entityManager, _configs),
                new PlayerHeroInitializeSystem(_entityManager, _configs),
                new BuildingZoneInitializeSystem(_entityManager, _configs),
                new UiInitializeSystem(_entityManager, _eventManager, _configs),

                new PlayerMoveSystem(_entityManager, _eventManager),
                new CameraFollowSystem(_entityManager, _eventManager),
                new BuildSystem(_entityManager, _eventManager, _configs),
            };
        }

        private void Update()
        {
            foreach (var system in _systems)
                system.Update();
        }
    }
}