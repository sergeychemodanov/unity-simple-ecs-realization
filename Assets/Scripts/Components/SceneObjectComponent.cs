using UnityEngine;

namespace SurvivalExample
{
    public class SceneObjectComponent : BaseComponent
    {
        public GameObject Prefab { get; private set; }
        public GameObject GameObject { get; private set; }

        public SceneObjectComponent(GameObject prefab, Transform parent = null)
        {
            Prefab = prefab;
            GameObject = Object.Instantiate(prefab, parent, false);
        }

        public SceneObjectComponent(GameObject prefab, Vector3 position, Transform parent = null)
        {
            Prefab = prefab;
            GameObject = Object.Instantiate(prefab, parent, false);
            GameObject.transform.position = position;
        }

        public void SetPosition(Vector3 position)
        {
            GameObject.transform.position = position;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            if (GameObject != null)
                Object.Destroy(GameObject);
        }
    }
}