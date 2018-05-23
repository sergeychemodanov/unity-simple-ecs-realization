using UnityEngine;

namespace SurvivalExample
{
    public class SceneObjectComponent : BaseComponent
    {
        public GameObject Prefab { get; private set; }
        public GameObject GameObject { get; private set; }

        public SceneObjectComponent(GameObject prefab, Transform parent = null, bool worldPositionStays = false)
        {
            Prefab = prefab;
            GameObject = Object.Instantiate(prefab, parent, worldPositionStays);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            if (GameObject != null)
                Object.Destroy(GameObject);
        }
    }
}