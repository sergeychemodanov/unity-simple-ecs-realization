using System.Collections.Generic;

namespace SurvivalExample
{
    public class CreateLevelSystem : ISystem
    {
        public CreateLevelSystem()
        {
            var groundComponents = new List<IComponent>
            {
                new SceneObjectComponent(Constants.GroundPrefabResourcePath),
            };

            EntityManager.Create(groundComponents);
        }

        public void Update()
        {
        }
    }
}