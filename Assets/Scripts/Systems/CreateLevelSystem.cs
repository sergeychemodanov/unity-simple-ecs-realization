using System.Collections.Generic;

namespace SurvivalExample
{
    public class CreateLevelSystem : BaseSystem
    {
        public CreateLevelSystem()
        {
            var groundComponents = new List<BaseComponent>
            {
                new SceneObjectComponent(Constants.GroundPrefabResourcePath),
            };

            EntityManager.Create(groundComponents);
        }
    }
}