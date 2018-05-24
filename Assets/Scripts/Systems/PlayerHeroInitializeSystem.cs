namespace SurvivalExample
{
    public class PlayerHeroInitializeSystem : BaseSystem
    {
        public PlayerHeroInitializeSystem(EntityManager entityManager, Configs configs)
        {
            entityManager.Create()
                .AddComponent(new PlayerHeroComponent())
                .AddComponent(new SceneObjectComponent(configs.PlayerHeroPrefab))
                .AddComponent(new MovementComponent(5f));
        }
    }
}