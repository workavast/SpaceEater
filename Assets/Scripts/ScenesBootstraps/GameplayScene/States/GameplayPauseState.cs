using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayPauseState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly StaticEatableObjectsRepository _staticEatableObjectsRepository;
        private readonly BlackHoleBehaviour _blackHoleBehaviour;
        private readonly EnemiesRepository _enemiesRepository;
        
        public GameplayPauseState(GameplaySceneContext context)
        {
            _uiController = context.UIController;

            _staticEatableObjectsRepository = context.StaticEatableObjectsRepository;
            _enemiesRepository = context.EnemiesRepository;
            _blackHoleBehaviour = context.BlackHoleBehaviour;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayMenuScreen>();

            _blackHoleBehaviour.SetAnimationState(false);
           
            foreach (var staticEatableObject in _staticEatableObjectsRepository.EatableObjects)
                staticEatableObject.SetAnimationState(false);
           
            foreach (var enemy in _enemiesRepository.Enemies)
                enemy.SetAnimationState(false);
        }

        public override void Exit()
        {
            _blackHoleBehaviour.SetAnimationState(true);
            
            foreach (var staticEatableObject in _staticEatableObjectsRepository.EatableObjects)
                staticEatableObject.SetAnimationState(true);
            
            foreach (var enemy in _enemiesRepository.Enemies)
                enemy.SetAnimationState(true);
        }

        public override void ManualUpdate()
        {
        }

        public override void ManualFixedUpdate()
        {
        }
    }
}