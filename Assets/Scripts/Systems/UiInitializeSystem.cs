using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SurvivalExample
{
    public class UiInitializeSystem : BaseSystem
    {
        private readonly EntityManager _entityManager;
        private readonly EventManager _eventManager;
        private readonly Configs _configs;
        private readonly Transform _canvasGo;

        public UiInitializeSystem(EntityManager entityManager, EventManager eventManager, Configs configs)
        {
            _entityManager = entityManager;
            _eventManager = eventManager;
            _configs = configs;

            var uiCameraEntity = entityManager.Entities
                .WithComponent<UiCameraComponent>()
                .WithComponent<SceneObjectComponent>().FirstOrDefault();

            if (uiCameraEntity == null)
                return;

            var uiCameraGo = uiCameraEntity.GetComponent<SceneObjectComponent>().GameObject;
            if (uiCameraGo.transform.childCount <= 0)
                return;

            _canvasGo = uiCameraGo.transform.GetChild(0);

            CreateButton("Floor", OnFloorClicked, new Vector2(20, -20));
            CreateButton("Build", OnBuildClick, new Vector2(70, -20));
        }

        private void CreateButton(string name, UnityAction onClick, Vector2 offset)
        {
            var buttonEntity = _entityManager.Create()
                .AddComponent(new SceneObjectComponent(_configs.UiButtonPrefab, _canvasGo));

            var buttonGameObject = buttonEntity.GetComponent<SceneObjectComponent>().GameObject;
            var button = buttonGameObject.GetComponent<Button>();
            var buttonText = buttonGameObject.GetComponentInChildren<Text>();
            var buttonRect = buttonGameObject.GetComponent<RectTransform>();

            buttonText.text = name;
            button.onClick.AddListener(onClick);
            buttonRect.anchoredPosition += offset;
        }

        private void OnFloorClicked()
        {
            var startBuildEvent = new StartBuildEvent();
            _eventManager.Publish(startBuildEvent);
        }

        private void OnBuildClick()
        {
            var buildEvent = new BuildEvent();
            _eventManager.Publish(buildEvent);
        }
    }
}