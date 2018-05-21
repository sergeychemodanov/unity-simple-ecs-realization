using UnityEngine;

namespace SurvivalExample
{
    public class SceneObjectComponent : BaseComponent
    {
        public string ResourcePath { get; private set; }
        public GameObject GameObject { get; private set; }

        public SceneObjectComponent(string resourcePath)
        {
            ResourcePath = resourcePath;
        }

        public void SetGameObject(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}