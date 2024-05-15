using SourceCode.Bootstraps.GameFMS;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.Bootstraps.GameplayScene
{
    public class GameplayEndState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly EnemiesUpdater _enemiesUpdater;
        private readonly StaticEatableObjectsUpdater _staticEatableObjectsUpdater;
        private readonly PlayerController _playerController;

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