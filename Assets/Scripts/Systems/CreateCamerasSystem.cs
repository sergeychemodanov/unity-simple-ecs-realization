namespace SurvivalExample
{
    public class CreateCamerasSystem : BaseSystem
    {
        public CreateCamerasSystem()
        {
            // main camera
            EntityManager.Create()
                .AddComponent(new SceneObjectComponent(Constants.MainCameraContainerPrefabResourcePath))
                .AddComponent(new MainCameraComponent());

            // ui camera
            EntityManager.Create()
                .AddComponent(new SceneObjectComponent(Constants.UiCameraContainerPrefabResourcePath))
                .AddComponent(new UiCameraComponent());
        }
    }
}