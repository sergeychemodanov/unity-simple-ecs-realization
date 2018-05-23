using UnityEngine;

namespace SurvivalExample
{
    public class BuildingZoneCellComponent : BaseComponent
    {
        public Vector3 Position { get; private set; }

        public BuildingZoneCellComponent(Vector3 position)
        {
            Position = position;
        }
    }
}