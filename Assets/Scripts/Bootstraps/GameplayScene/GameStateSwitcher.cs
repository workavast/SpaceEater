using SourceCode.Bootstraps.GameFMS;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.Bootstraps.GameplayScene
{
    public class GameStateSwitcher
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly EndGameDetector _endGameDetector;

        public GameStateSwitcher(GameStateMachine gameStateMachine, EndGameDetector endGameDetector)
        {
            _gameStateMachine = gameStateMachine;
            _endGameDetector = endGameDetector;

            _endGameDetector.GameEnded += OnGameEnded;
            
            var gameplayMainScreen = UI_ScreenRepository.GetScreen<GameplayMainScreen>();
            gameplayMainScreen.PauseButtonClicked += OnGamePaused;
            
            var gameplayMenuScreen = UI_ScreenRepository.GetScreen<GameplayMenuScreen>();
            gameplayMenuScreen.ContinueButtonClicked += OnGameContinued;
        }
        
        private void OnGameEnded()
            => _gameStateMachine.SetState<GameplayEndState>();
        
        private void OnGamePaused()
            => _gameStateMachine.SetState<GameplayPauseState>();

        private void OnGameContinued()
            => _gameStateMachine.SetState<GameplayMainState>();
    }
}