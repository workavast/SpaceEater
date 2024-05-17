using System.Collections.Generic;
using SourceCode.BackgroundControl;
using SourceCode.CameraMovement;
using SourceCode.Core.PlayZone;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies.Factory;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects.EnvironmentSpawning;
using SourceCode.Entities.StaticEatableObjects.Factory;
using SourceCode.ScenesBootstraps.GameplayScene.States;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using UnityEngine;
using Zenject;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private BackgroundController backgroundController;
        [SerializeField] private BlackHoleBehaviour blackHoleBehaviour;

        [Inject] private readonly GameEndDetectorConfig _gameEndDetectorConfig;
        [Inject] private readonly StaticEatableObjectsFactory _staticEatableObjectsFactory;
        [Inject] private readonly EnvironmentSpawnConfig _environmentSpawnConfig;
        [Inject] private readonly EnemiesSpawnConfig _enemiesSpawnConfig;
        [Inject] private readonly EnemiesFactory _enemiesFactory;
        [Inject] private readonly PlayZoneConfig _playZoneConfig;
        [Inject] private readonly UI_Controller _uiController;

        private GameStateMachine _gameStateMachine;
        private GameStateSwitcher _gameStateSwitcher;
        private GameplaySceneContext _gameplaySceneContext;
        
        private void Start()
        {
            _gameplaySceneContext = new GameplaySceneContext(
                _uiController,
                blackHoleBehaviour, 
                _enemiesFactory, 
                _staticEatableObjectsFactory,
                _enemiesSpawnConfig, 
                _playZoneConfig, 
                _environmentSpawnConfig, 
                _gameEndDetectorConfig);
            
            var gameplaySceneLoadDetector = new GameplaySceneLoadDetector(_gameplaySceneContext.SceneLoader);
            
            var gameplayInitState = new GameplayInitState(_gameplaySceneContext, cameraController, backgroundController);
            var gameplayLoadingScreenFadeState = new GameplayLoadingScreenFadeState();
            var states = new List<GameStateBase>
            {
                gameplayInitState,
                gameplayLoadingScreenFadeState,
                new GameplayMainState(_gameplaySceneContext),
                new GameplayPauseState(_gameplaySceneContext),
                new GameplayEndState(_gameplaySceneContext)
            };
            _gameStateMachine = new GameStateMachine(states);
            _gameStateSwitcher = new GameStateSwitcher(_gameStateMachine, _gameplaySceneContext.EndGameDetector,
                gameplayInitState, gameplayLoadingScreenFadeState);
            
            _gameStateMachine.Init(typeof(GameplayInitState));
        }

        private void Update() 
            => _gameStateMachine.ManualUpdate();

        private void FixedUpdate() 
            => _gameStateMachine.ManualFixedUpdate();
    }
}