using SourceCode.Ad;
using SourceCode.Ad.Preparing;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.GameplayScene.EndGameDetection;
using SourceCode.ScenesBootstraps.GameplayScene.States;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class GameStateSwitcher
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly EndGameDetector _endGameDetector;
        private readonly GameplayInitState _gameplayInitState;
        private readonly GameplayLoadingScreenFadeState _gameplayLoadingScreenFadeState;
        private readonly GameplayAdShowState _gameplayAdShowState;
        private readonly IAdPreparedTrigger _adPreparedTrigger;

        public GameStateSwitcher(GameStateMachine gameStateMachine, GameplayInitState gameplayInitState, 
            GameplayLoadingScreenFadeState gameplayLoadingScreenFadeState, GameplayAdShowState gameplayAdShowState, 
            GameplaySceneContext context)
        {
            _gameStateMachine = gameStateMachine;
            _gameplayInitState = gameplayInitState;
            _gameplayLoadingScreenFadeState = gameplayLoadingScreenFadeState;
            _gameplayAdShowState = gameplayAdShowState;
            _endGameDetector = context.EndGameDetector;
            _adPreparedTrigger = context.AdPreparedTrigger;

            _gameplayInitState.Initialized += OnGameInitialized;
            _gameplayLoadingScreenFadeState.FadeEnded += OnGameFadeEnded;
            _endGameDetector.GameEnded += OnGameEnded;
            _gameplayAdShowState.AdShowEnded += OnAdShowEnded;
            _adPreparedTrigger.AdPreparingTriggered += OnAdPreparingTriggered;
            
            var gameplayMainScreen = UI_ScreenRepository.GetScreen<GameplayMainScreen>();
            gameplayMainScreen.PauseButtonClicked += OnGamePaused;
            
            var gameplayMenuScreen = UI_ScreenRepository.GetScreen<GameplayMenuScreen>();
            gameplayMenuScreen.ContinueButtonClicked += OnGameContinued;
        }

        private void OnAdPreparingTriggered()
        {
            if(_gameStateMachine.CurrentState != typeof(GameplayMainState))
                return;
            
            _gameStateMachine.SetState<GameplayAdShowState>();
        }
        
        private void OnAdShowEnded()
            => _gameStateMachine.SetState<GameplayPauseState>();

        private void OnGameInitialized()
            => _gameStateMachine.SetState<GameplayLoadingScreenFadeState>();

        private void OnGameFadeEnded() 
            => _gameStateMachine.SetState<GameplayMainState>();

        private void OnGameEnded()
            => _gameStateMachine.SetState<GameplayEndState>();
        
        private void OnGamePaused()
            => _gameStateMachine.SetState<GameplayPauseState>();

        private void OnGameContinued()
            => _gameStateMachine.SetState<GameplayMainState>();
    }
}