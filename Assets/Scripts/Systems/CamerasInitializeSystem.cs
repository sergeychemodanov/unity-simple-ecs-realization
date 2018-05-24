namespace SurvivalExample
{
    public class CamerasInitializeSystem : BaseSystem
    {
        public CamerasInitializeSystem(EntityManager entityManager, Configs configs)
        {
            // main camera
            entityManager.Create()
                .AddComponent(new SceneObjectComponent(configs.MainCameraContainerPrefab))
                .AddComponent(new MainCameraComponent());

            // ui camera
            entityManager.Create()
                .AddComponent(new SceneObjectComponent(configs.UiCameraContainerPrefab))
                .AddComponent(new UiCameraComponent());
        }
    }
}