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

        public GameStateSwitcher(GameStateMachine gameStateMachine, EndGameDetector endGameDetector, 
            GameplayInitState gameplayInitState)
        {
            _gameStateMachine = gameStateMachine;
            _endGameDetector = endGameDetector;
            
            gameplayInitState.Initialized += OnGameInitialized;
                
            _endGameDetector.GameEnded += OnGameEnded;
            
            var gameplayMainScreen = UI_ScreenRepository.GetScreen<GameplayMainScreen>();
            gameplayMainScreen.PauseButtonClicked += OnGamePaused;
            
            var gameplayMenuScreen = UI_ScreenRepository.GetScreen<GameplayMenuScreen>();
            gameplayMenuScreen.ContinueButtonClicked += OnGameContinued;
        }
        
        private void OnGameInitialized()
            => _gameStateMachine.SetState<GameplayMainState>();
        
        private void OnGameEnded()
            => _gameStateMachine.SetState<GameplayEndState>();
        
        private void OnGamePaused()
            => _gameStateMachine.SetState<GameplayPauseState>();

        private void OnGameContinued()
            => _gameStateMachine.SetState<GameplayMainState>();
    }
}