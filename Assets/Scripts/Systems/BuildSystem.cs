using System.Linq;
using UnityEngine;

namespace SurvivalExample
{
    public class BuildSystem : BaseSystem
    {
        private readonly EntityManager _entityManager;
        private readonly Configs _configs;
        private readonly Transform _playerHeroTransform;

        private bool _buildStarted;

        private BaseEntity _nearestCellEntity;
        private BuildingZoneCellComponent _nearestCell;
        private float _nearestCellDistance = float.MaxValue;


        public BuildSystem(EntityManager entityManager, EventManager eventManager, Configs configs)
        {
            _entityManager = entityManager;
            _configs = configs;

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
                var playerForwardPosition = _playerHeroTransform.position + _playerHeroTransform.forward;
                _nearestCellDistance = Vector3.Distance(playerForwardPosition, _nearestCell.Position);
                if (_nearestCellDistance > _configs.CellSize)
                {
                    AddBuildingCellSceneObject();
                    ClearNearestCell();
                }
            }

            GetNearestCell();
        }


        private void GetNearestCell()
        {
            var cellsEntities = _entityManager.Entities.WithComponent<BuildingZoneCellComponent>();

            foreach (var cellEntity in cellsEntities)
            {
                var cell = cellEntity.GetComponent<BuildingZoneCellComponent>();

                if (_nearestCellEntity != null && _nearestCell == cell)
                    continue;

                var playerForwardPosition = _playerHeroTransform.position + _playerHeroTransform.forward;
                var distance = Vector3.Distance(playerForwardPosition, cell.Position);
                if (distance > _configs.CellSize || distance > _nearestCellDistance)
                    continue;

                var cellFloorComponent = cellEntity.GetComponent<FloorComponent>();
                if (cellFloorComponent != null)
                    continue;

                if (_nearestCellEntity != null)
                    AddBuildingCellSceneObject();

                _nearestCellDistance = distance;
                _nearestCellEntity = cellEntity;
                _nearestCell = cell;

                _nearestCellEntity.RemoveComponents<SceneObjectComponent>();
                _nearestCellEntity.AddComponent(new SceneObjectComponent(_configs.FloorCanBuildedPrefab, cell.Position));
            }
        }

        private void ClearNearestCell()
        {
            _nearestCellEntity = null;
            _nearestCell = null;
            _nearestCellDistance = float.MaxValue;
        }

        private void AddBuildingCellSceneObject()
        {
            _nearestCellEntity.RemoveComponents<SceneObjectComponent>();
            _nearestCellEntity.AddComponent(new SceneObjectComponent(_configs.BuildingZoneCellPrefab, _nearestCell.Position));
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

            _nearestCellEntity.RemoveComponents<SceneObjectComponent>();
            _nearestCellEntity.AddComponent(new SceneObjectComponent(_configs.FloorBuildedPrefab, _nearestCell.Position));

            ClearNearestCell();
        }
    }
}