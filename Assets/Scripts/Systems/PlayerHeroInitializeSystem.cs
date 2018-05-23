namespace SurvivalExample
{
    public class PlayerHeroInitializeSystem : BaseSystem
    {
        public PlayerHeroInitializeSystem(EntityManager entityManager, Globals globals)
        {
            entityManager.Create()
                .AddComponent(new PlayerHeroComponent())
                .AddComponent(new SceneObjectComponent(globals.PlayerHeroPrefab))
                .AddComponent(new MovementComponent(5f));
        }
    }
}