namespace SurvivalExample
{
    public class CreatePlayerHeroSystem : BaseSystem
    {
        public CreatePlayerHeroSystem(EntityManager entityManager)
        {
            entityManager.Create()
                .AddComponent(new PlayerHeroComponent())
                .AddComponent(new SceneObjectComponent(Constants.PlayerPrefabResourcePath))
                .AddComponent(new MovementComponent(5f));
        }
    }
}