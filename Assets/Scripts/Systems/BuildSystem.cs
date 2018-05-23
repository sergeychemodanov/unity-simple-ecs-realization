using System.Linq;
using UnityEngine;

namespace SurvivalExample
{
    public class BuildSystem : BaseSystem
    {
        private readonly EntityManager _entityManager;
        private readonly Globals _globals;
        private readonly Transform _playerHeroTransform;

        private bool _buildStarted;
        private float _nearestCellDistance = 999f;
        private BuildingZoneCellComponent _nearestCell;
        private BaseEntity _nearestCellEntity;

        public BuildSystem(EntityManager entityManager, EventManager eventManager, Globals globals)
        {
            _entityManager = entityManager;
            _globals = globals;

            var playerHeroEntity = _entityManager.Entities
                .WithComponent<PlayerHeroComponent>()
                .WithComponent<SceneObjectComponent>().FirstOrDefault();

            if (playerHeroEntity != null)
                _playerHeroTransform = playerHeroEntity.GetComponent<SceneObjectComponent>().GameObject.transform;

            eventManager.Subscribe<StartBuildEvent>(OnStartBuild);
            eventManager.Subscribe<BuildEvent>(OnBuild);
        }

        public override void Update()
        {
            base.Update();
            if (!_buildStarted || _playerHeroTransform == null)
                return;

            if (_nearestCellEntity != null)
            {
                var distance = Vector3.Distance(_playerHeroTransform.position, _nearestCell.Position);
                if (distance > _globals.MinBuildingDistance)
                    ClearSceneObjectComponent(_nearestCellEntity);
            }

            var cells = _entityManager.Entities.WithComponent<BuildingZoneCellComponent>();
            foreach (var cell in cells)
            {
                var cellComponent = cell.GetComponent<BuildingZoneCellComponent>();
                var distance = Vector3.Distance(_playerHeroTransform.position, cellComponent.Position);
                if (distance > _globals.MinBuildingDistance)
                    continue;

                if (distance > _nearestCellDistance)
                    continue;

                var cellFloorComponent = cell.GetComponent<FloorComponent>();
                if (cellFloorComponent != null)
                    continue;

                if (_nearestCellEntity != null)
                    ClearSceneObjectComponent(_nearestCellEntity);

                _nearestCell = cellComponent;
                _nearestCellDistance = distance;
                _nearestCellEntity = cell;
                _nearestCellEntity.AddComponent(new SceneObjectComponent(_globals.FloorCanBuildedPrefab));
            }
        }

        private void OnStartBuild(StartBuildEvent eventData)
        {
            _buildStarted = true;
        }

        private void OnBuild(BuildEvent eventData)
        {
            _buildStarted = false;
            if (_nearestCellEntity == null)
                return;

            _nearestCellEntity.AddComponent(new FloorComponent());
            ClearSceneObjectComponent(_nearestCellEntity);
            _nearestCellEntity.AddComponent(new SceneObjectComponent(_globals.FloorBuildedPrefab));
        }

        private void ClearSceneObjectComponent(BaseEntity entity)
        {
            var sceneObjectComponent = entity.GetComponent<SceneObjectComponent>();
            if (sceneObjectComponent != null)
                entity.RemoveComponent(sceneObjectComponent);
        }
    }
}