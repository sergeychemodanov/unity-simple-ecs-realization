using UnityEngine;

namespace SurvivalExample
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Globals _globals;

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

                new CamerasInitializeSystem(_entityManager, _globals),
                new LevelInitializeSystem(_entityManager, _globals),
                new PlayerHeroInitializeSystem(_entityManager, _globals),
                new BuildingZoneInitializeSystem(_entityManager, _globals),
                new BuildSystem(_entityManager, _eventManager, _globals),
                new UiInitializeSystem(_entityManager, _eventManager, _globals),

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