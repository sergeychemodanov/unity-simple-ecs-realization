using UnityEngine;

namespace SurvivalExample
{
    public class SystemManager : MonoBehaviour
    {
        private ISystem[] _systems;

        private void Start()
        {
            _systems = new ISystem[]
            {
#if UNITY_STANDALONE || UNITY_EDITOR
                new StandaloneInputSystem(),
#elif UNITY_ANDROID || UNITY_IOS
// TODO create mobile input system
#endif
                new CreateLevelSystem(),
            };
        }

        private void Update()
        {
            foreach (var system in _systems)
                system.Update();
        }
    }
}