using UnityEngine;

namespace SurvivalExample
{
    public class BuildingZoneInitializeSystem : BaseSystem
    {
        public BuildingZoneInitializeSystem(EntityManager entityManager, Configs configs)
        {
            for (var x = 0; x < configs.BuildingZoneSize.x; x++)
            {
                for (var y = 0; y < configs.BuildingZoneSize.y; y++)
                {
                    for (var z = 0; z < configs.BuildingZoneSize.z; z++)
                    {
                        var position = new Vector3(x * configs.CellSize, y * configs.CellSize, z * configs.CellSize);
                        entityManager.Create()
                            .AddComponent(new BuildingZoneCellComponent(position))
                            .AddComponent(new SceneObjectComponent(configs.BuildingZoneCellPrefab, position));
                    }
                }
            }
        }
    }
}