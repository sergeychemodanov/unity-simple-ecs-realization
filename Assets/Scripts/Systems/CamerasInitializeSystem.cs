namespace SurvivalExample
{
    public class CamerasInitializeSystem : BaseSystem
    {
        public CamerasInitializeSystem(EntityManager entityManager, Globals globals)
        {
            // main camera
            entityManager.Create()
                .AddComponent(new SceneObjectComponent(globals.MainCameraContainerPrefab))
                .AddComponent(new MainCameraComponent());

            // ui camera
            entityManager.Create()
                .AddComponent(new SceneObjectComponent(globals.UiCameraContainerPrefab))
                .AddComponent(new UiCameraComponent());
        }
    }
}