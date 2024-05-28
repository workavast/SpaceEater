using SourceCode.Entities.BlackHole.BlackHoleUpdating;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;
using YG;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayEndState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly IEnemiesUpdater _enemiesUpdater;
        private readonly IStaticEatableObjectsUpdater _staticEatableObjectsUpdater;
        private readonly IBlackHoleUpdater _blackHoleUpdater;

        public GameplayEndState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
            _enemiesUpdater = context.EnemiesUpdater;
            _staticEatableObjectsUpdater = context.StaticEatableObjectsUpdater;
            _blackHoleUpdater = context.BlackHoleUpdater;
        }
        
        public GameplayEndState(
            UI_Controller uiController, 
            IEnemiesUpdater enemiesUpdater, 
            IStaticEatableObjectsUpdater staticEatableObjectsUpdater,
            IBlackHoleUpdater blackHoleUpdater)
        {
            _uiController = uiController;
            _enemiesUpdater = enemiesUpdater;
            _staticEatableObjectsUpdater = staticEatableObjectsUpdater;
            _blackHoleUpdater = blackHoleUpdater;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayEndScreen>();
            var gameplayEndScreen = UI_ScreenRepository.GetScreen<GameplayEndScreen>();
            gameplayEndScreen.SetGameSuccess(_blackHoleUpdater.PlayerIsAlive);
            YandexGame.ReviewShow(YandexGame.auth);
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