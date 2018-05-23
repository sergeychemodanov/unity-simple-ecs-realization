namespace SurvivalExample
{
    public class CreateCamerasSystem : BaseSystem
    {
        public CreateCamerasSystem(EntityManager entityManager)
        {
            // main camera
            entityManager.Create()
                .AddComponent(new SceneObjectComponent(Constants.MainCameraContainerPrefabResourcePath))
                .AddComponent(new MainCameraComponent());

            // ui camera
            entityManager.Create()
                .AddComponent(new SceneObjectComponent(Constants.UiCameraContainerPrefabResourcePath))
                .AddComponent(new UiCameraComponent());
        }
    }
}