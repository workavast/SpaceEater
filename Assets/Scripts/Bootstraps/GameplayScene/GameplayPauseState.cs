using SourceCode.Bootstraps.GameFMS;
using SourceCode.Ui.UiSystem;

namespace SourceCode.Bootstraps.GameplayScene
{
    public class GameplayPauseState : GameStateBase
    {
        private readonly UI_Controller _uiController;

        public GameplayPauseState(UI_Controller uiController)
        {
            _uiController = uiController;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen(ScreenType.GameplayMenu);
        }

        public override void Exit()
        {
        }

        public override void ManualUpdate()
        {
        }

        public override void ManualFixedUpdate()
        {
        }
    }
}