namespace SurvivalExample
{
    public class LevelInitializeSystem : BaseSystem
    {
        public LevelInitializeSystem(EntityManager entityManager, Globals globals)
        {
            entityManager.Create().AddComponent(new SceneObjectComponent(globals.GroundPrefab));
        }
    }
}