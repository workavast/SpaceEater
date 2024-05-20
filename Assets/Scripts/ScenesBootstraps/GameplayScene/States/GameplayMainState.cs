using SourceCode.Core.Ad;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayMainState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly EnemiesUpdater _enemiesUpdater;
        private readonly StaticEatableObjectsUpdater _staticEatableObjectsUpdater;
        private readonly PlayerController _playerController;
        private readonly IAdTrigger _adTrigger;
        
        public GameplayMainState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
            _enemiesUpdater = context.EnemiesUpdater;
            _staticEatableObjectsUpdater = context.StaticEatableObjectsUpdater;
            _playerController = context.PlayerController;
            _adTrigger = context.AdController;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayMainScreen>();
        }

        public override void Exit()
        {
        }

        public override void ManualUpdate()
        {
            _enemiesUpdater.ManualUpdate();
            _staticEatableObjectsUpdater.ManualUpdate();
            _playerController.ManualUpdate();

            _adTrigger.TryActivateFullScreenAd();
        }

        public override void ManualFixedUpdate()
        {
        }
    }
}