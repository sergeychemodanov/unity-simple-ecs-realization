using System.Collections.Generic;

namespace SurvivalExample
{
    public class CreatePlayerSystem : BaseSystem
    {
        public CreatePlayerSystem()
        {
            var playerComponents = new List<BaseComponent>
            {
                new IsPlayerComponent(),
                new SceneObjectComponent(Constants.PlayerPrefabResourcePath),
                new MovementComponent(5f),
            };

            EntityManager.Create(playerComponents);
        }
    }
}