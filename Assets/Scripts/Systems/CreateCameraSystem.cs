using System.Collections.Generic;

namespace SurvivalExample
{
    public class CreateCameraSystem : BaseSystem
    {
        public CreateCameraSystem()
        {
            var cameraComponents = new List<BaseComponent>
            {
                new SceneObjectComponent(Constants.CameraPrefabResourcePath),
                new IsCameraComponent(),
            };

            EntityManager.Create(cameraComponents);
        }
    }
}