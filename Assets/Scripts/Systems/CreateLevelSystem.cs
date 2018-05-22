namespace SurvivalExample
{
    public class CreateLevelSystem : BaseSystem
    {
        public CreateLevelSystem()
        {
            EntityManager.Create().AddComponent(new SceneObjectComponent(Constants.GroundPrefabResourcePath));
        }
    }
}