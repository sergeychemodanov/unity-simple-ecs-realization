using UnityEngine;

namespace SurvivalExample
{
    public class SceneObjectComponent : IComponent
    {
        public string ResourcePath;
        public GameObject GameObject;

        public SceneObjectComponent(string resourcePath)
        {
            ResourcePath = resourcePath;
        }
    }
}