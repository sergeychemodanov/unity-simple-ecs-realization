namespace SurvivalExample
{
    public class CreateLevelSystem : BaseSystem
    {
        public CreateLevelSystem(EntityManager entityManager)
        {
            entityManager.Create().AddComponent(new SceneObjectComponent(Constants.GroundPrefabResourcePath));
        }
    }
}