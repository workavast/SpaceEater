using GameCycleFramework;
using SourceCode.BackgroundControl;
using SourceCode.CameraMovement;
using SourceCode.Core.PlayZone;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies.Factory;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Entities.StaticEatableObjects.Factory;
using SourceCode.EnvironmentSpawning;
using UnityEngine;
using Zenject;

namespace SourceCode.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private BackgroundController backgroundController;
        [SerializeField] private BlackHoleBehaviour blackHoleBehaviour;

        [Inject] private readonly IGameCycleController _gameCycleController;
        [Inject] private readonly StaticEatableObjectsFactory _staticEatableObjectsFactory;
        [Inject] private readonly EnvironmentSpawnConfig _environmentSpawnConfig;
        [Inject] private readonly EnemiesSpawnConfig _enemiesSpawnConfig;
        [Inject] private readonly EnemiesFactory _enemiesFactory;
        [Inject] private readonly PlayZoneConfig _playZoneConfig;
        
        private StaticEatableObjectsUpdater _staticEatableObjectsUpdater;
        private EnvironmentSpawner _environmentSpawner;
        private EnemiesSpawner _enemiesSpawner;
        
        private void Start()
        {
            FpsCap.Initialize();
            cameraController.SetFollowTarget(blackHoleBehaviour);
            backgroundController.SetTarget(blackHoleBehaviour);
            _staticEatableObjectsUpdater = new StaticEatableObjectsUpdater(_gameCycleController, _staticEatableObjectsFactory);
            _environmentSpawner = new EnvironmentSpawner(_environmentSpawnConfig, _staticEatableObjectsFactory);
            _environmentSpawner.Generate();

            _enemiesSpawner = new EnemiesSpawner(_enemiesSpawnConfig, _enemiesFactory, blackHoleBehaviour, _playZoneConfig);
        }
    }
}