using System.Collections.Generic;
using SourceCode.BackgroundControl;
using SourceCode.CameraMovement;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.GameplayScene.States;
using SourceCode.ScenesBootstraps.SceneFSM;
using UnityEngine;
using Zenject;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private BackgroundController backgroundController;

        [Inject] private readonly GameplaySceneContext _gameplaySceneContext;

        private GameStateMachine _gameStateMachine;
        private GameStateSwitcher _gameStateSwitcher;
        
        private void Start()
        {
            var gameplaySceneLoadDetector = new GameplaySceneLoadDetector(_gameplaySceneContext.SceneLoader);
            
            var gameplayInitState = new GameplayInitState(_gameplaySceneContext, cameraController, backgroundController);
            var gameplayLoadingScreenFadeState = new GameplayLoadingScreenFadeState();
            var gameplayAdShowState = new GameplayAdShowState(_gameplaySceneContext);
            var states = new List<GameStateBase>
            {
                gameplayInitState,
                gameplayLoadingScreenFadeState,
                gameplayAdShowState,
                new GameplayMainState(_gameplaySceneContext),
                new GameplayPauseState(_gameplaySceneContext),
                new GameplayEndState(_gameplaySceneContext)
            };
            _gameStateMachine = new GameStateMachine(states);
            _gameStateSwitcher = new GameStateSwitcher(_gameStateMachine, _gameplaySceneContext.EndGameDetector,
                gameplayInitState, gameplayLoadingScreenFadeState, gameplayAdShowState, _gameplaySceneContext.AdTrigger);

            _gameStateMachine.Init(typeof(GameplayInitState));
        }

        private void Update() 
            => _gameStateMachine.ManualUpdate();

        private void FixedUpdate() 
            => _gameStateMachine.ManualFixedUpdate();
    }
}