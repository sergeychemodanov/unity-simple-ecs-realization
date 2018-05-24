namespace SurvivalExample
{
    public class LevelInitializeSystem : BaseSystem
    {
        public LevelInitializeSystem(EntityManager entityManager, Configs configs)
        {
            entityManager.Create().AddComponent(new SceneObjectComponent(configs.GroundPrefab));
        }
    }
}