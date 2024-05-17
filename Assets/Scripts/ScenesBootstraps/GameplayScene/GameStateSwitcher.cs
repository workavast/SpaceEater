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

        public GameStateSwitcher(GameStateMachine gameStateMachine, EndGameDetector endGameDetector, 
            GameplayInitState gameplayInitState, GameplayLoadingScreenFadeState gameplayLoadingScreenFadeState)
        {
            _gameStateMachine = gameStateMachine;
            _endGameDetector = endGameDetector;
            _gameplayInitState = gameplayInitState;
            _gameplayLoadingScreenFadeState = gameplayLoadingScreenFadeState;

            _gameplayInitState.Initialized += OnGameInitialized;
            _gameplayLoadingScreenFadeState.FadeEnded += OnGameFadeEnded;
            _endGameDetector.GameEnded += OnGameEnded;
            
            var gameplayMainScreen = UI_ScreenRepository.GetScreen<GameplayMainScreen>();
            gameplayMainScreen.PauseButtonClicked += OnGamePaused;
            
            var gameplayMenuScreen = UI_ScreenRepository.GetScreen<GameplayMenuScreen>();
            gameplayMenuScreen.ContinueButtonClicked += OnGameContinued;
        }
        
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