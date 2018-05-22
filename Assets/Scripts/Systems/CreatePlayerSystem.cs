namespace SurvivalExample
{
    public class CreatePlayerSystem : BaseSystem
    {
        public CreatePlayerSystem()
        {
            EntityManager.Create()
                .AddComponent(new PlayerHeroComponent())
                .AddComponent(new SceneObjectComponent(Constants.PlayerPrefabResourcePath))
                .AddComponent(new MovementComponent(5f));
        }
    }
}