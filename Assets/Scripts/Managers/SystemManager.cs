using UnityEngine;

namespace SurvivalExample
{
    public class SystemManager : MonoBehaviour
    {
        private ISystem[] _systems;

        private void Start()
        {
            _systems = new ISystem[] { };
        }

        private void Update()
        {
            foreach (var system in _systems)
                system.Update();
        }
    }
}