using UnityEngine;

namespace SurvivalExample
{
    public class SystemManager : MonoBehaviour
    {
        private BaseSystem[] _systems;

        private void Start()
        {
            _systems = new BaseSystem[]
            {
#if UNITY_STANDALONE || UNITY_EDITOR
                new StandaloneInputSystem(),
#elif UNITY_ANDROID || UNITY_IOS
// TODO create mobile input system
#endif

                new CreateCamerasSystem(),
                new CreateLevelSystem(),
                new CreatePlayerSystem(),

                new PlayerMoveSystem(),
                new CameraFollowSystem(),
            };
        }

        private void Update()
        {
            foreach (var system in _systems)
                system.Update();
        }
    }
}