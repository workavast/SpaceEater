using System.Collections.Generic;
using SourceCode.BackgroundControl;
using SourceCode.Bootstraps.GameFMS;
using SourceCode.CameraMovement;
using SourceCode.Core;
using SourceCode.Core.PlayZone;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.Enemies.Factory;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Entities.StaticEatableObjects.Factory;
using SourceCode.EnvironmentSpawning;
using SourceCode.Ui.UiSystem;
using UnityEngine;
using Zenject;

namespace SourceCode.Bootstraps.GameplayScene
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private BackgroundController backgroundController;
        [SerializeField] private BlackHoleBehaviour blackHoleBehaviour;

        [Inject] private readonly StaticEatableObjectsFactory _staticEatableObjectsFactory;
        [Inject] private readonly EnvironmentSpawnConfig _environmentSpawnConfig;
        [Inject] private readonly EnemiesSpawnConfig _enemiesSpawnConfig;
        [Inject] private readonly EnemiesFactory _enemiesFactory;
        [Inject] private readonly PlayZoneConfig _playZoneConfig;
        [Inject] private readonly UI_Controller _uiController;
        
        private StaticEatableObjectsUpdater _staticEatableObjectsUpdater;
        private EnvironmentSpawner _environmentSpawner;
        private EnemiesSpawner _enemiesSpawner;
        private EnemiesUpdater _enemiesUpdater;
        private GameStateMachine _gameStateMachine;
        private EndGameDetector _endGameDetector;
        private GameStateSwitcher _gameStateSwitcher;
        private GameSceneLoader _gameSceneLoader;
        private PlayerController _playerController;

        private void Start()
        {
            YandexPluginGameReadyApiInitializer.Initialize();
            FpsCap.Initialize();
            
            cameraController.SetFollowTarget(blackHoleBehaviour);
            backgroundController.SetTarget(blackHoleBehaviour);

            _uiController.Initialize();
            _playerController = new PlayerController(blackHoleBehaviour);
            _enemiesUpdater = new EnemiesUpdater(_enemiesFactory);
            _endGameDetector = new EndGameDetector(blackHoleBehaviour);
            _staticEatableObjectsUpdater = new StaticEatableObjectsUpdater(_staticEatableObjectsFactory);
            _environmentSpawner = new EnvironmentSpawner(_environmentSpawnConfig, _staticEatableObjectsFactory);
            _enemiesSpawner = new EnemiesSpawner(_enemiesSpawnConfig, _enemiesFactory, blackHoleBehaviour, _playZoneConfig);
            
            var states = new List<GameStateBase>
            {
                new GameplayMainState(_uiController, _enemiesUpdater, _staticEatableObjectsUpdater, _playerController),
                new GameplayPauseState(_uiController),
                new GameplayEndState(_uiController, _enemiesUpdater, _staticEatableObjectsUpdater, _playerController)
            };
            _gameStateMachine = new GameStateMachine(typeof(GameplayMainState), states);
            _gameStateSwitcher = new GameStateSwitcher(_gameStateMachine, blackHoleBehaviour);
            _gameSceneLoader = new GameSceneLoader(); 
            
            _environmentSpawner.Generate();
        }

        private void Update() 
            => _gameStateMachine.ManualUpdate();

        private void FixedUpdate() 
            => _gameStateMachine.ManualFixedUpdate();
    }
}