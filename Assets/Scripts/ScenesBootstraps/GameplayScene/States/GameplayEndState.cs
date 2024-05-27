using SourceCode.Core;
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
        private readonly EnemiesUpdater _enemiesUpdater;
        private readonly StaticEatableObjectsUpdater _staticEatableObjectsUpdater;
        private readonly PlayerController _playerController;

        public GameplayEndState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
            _enemiesUpdater = context.EnemiesUpdater;
            _staticEatableObjectsUpdater = context.StaticEatableObjectsUpdater;
            _playerController = context.PlayerController;
        }
        
        public GameplayEndState(
            UI_Controller uiController, 
            EnemiesUpdater enemiesUpdater, 
            StaticEatableObjectsUpdater staticEatableObjectsUpdater,
            PlayerController playerController)
        {
            _uiController = uiController;
            _enemiesUpdater = enemiesUpdater;
            _staticEatableObjectsUpdater = staticEatableObjectsUpdater;
            _playerController = playerController;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayEndScreen>();
            var gameplayEndScreen = UI_ScreenRepository.GetScreen<GameplayEndScreen>();
            gameplayEndScreen.SetGameSuccess(_playerController.PlayerIsAlive);
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