using UnityEngine;

namespace SurvivalExample
{
    public class BuildingZoneInitializeSystem : BaseSystem
    {
        public BuildingZoneInitializeSystem(EntityManager entityManager, Globals globals)
        {
            for (var x = 0; x < globals.BuildingZoneSize.x; x++)
            {
                for (var y = 0; y < globals.BuildingZoneSize.y; y++)
                {
                    for (var z = 0; z < globals.BuildingZoneSize.z; z++)
                    {
                        entityManager.Create()
                            .AddComponent(new BuildingZoneCellComponent(new Vector3(x, y, z)));
                    }
                }
            }
        }
    }
}