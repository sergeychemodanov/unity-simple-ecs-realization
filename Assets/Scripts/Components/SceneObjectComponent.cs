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

            var prefab = Resources.Load<GameObject>(ResourcePath);
            GameObject = Object.Instantiate(prefab);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            if (GameObject != null)
                Object.Destroy(GameObject);
        }
    }
}