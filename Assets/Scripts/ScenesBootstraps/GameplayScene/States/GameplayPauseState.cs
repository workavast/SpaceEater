using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayPauseState : GameStateBase
    {
        private readonly UI_Controller _uiController;

        public GameplayPauseState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayMenuScreen>();
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