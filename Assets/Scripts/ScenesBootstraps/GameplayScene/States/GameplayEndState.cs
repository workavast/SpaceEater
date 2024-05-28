using SourceCode.Entities.BlackHole.BlackHoleUpdating;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.ReviewRequest;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayEndState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly IEnemiesUpdater _enemiesUpdater;
        private readonly IStaticEatableObjectsUpdater _staticEatableObjectsUpdater;
        private readonly IBlackHoleUpdater _blackHoleUpdater;
        private readonly IReviewRequester _reviewRequester;

        public GameplayEndState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
            _enemiesUpdater = context.EnemiesUpdater;
            _staticEatableObjectsUpdater = context.StaticEatableObjectsUpdater;
            _blackHoleUpdater = context.BlackHoleUpdater;
            _reviewRequester = context.ReviewRequester;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayEndScreen>();
            var gameplayEndScreen = UI_ScreenRepository.GetScreen<GameplayEndScreen>();
            gameplayEndScreen.SetGameSuccess(_blackHoleUpdater.PlayerIsAlive);
            _reviewRequester.SendRequest();
        }

        public override void Exit()
        {
        }

        public override void ManualUpdate()
        {
            _enemiesUpdater.ManualUpdate();
            _staticEatableObjectsUpdater.ManualUpdate();
        }

        public override void ManualFixedUpdate()
        {
        }
    }
}