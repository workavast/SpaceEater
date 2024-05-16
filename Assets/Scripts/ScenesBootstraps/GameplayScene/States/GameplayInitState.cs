using System;
using SourceCode.BackgroundControl;
using SourceCode.CameraMovement;
using SourceCode.Core;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.StaticEatableObjects.EnvironmentSpawning;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayInitState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly CameraController _cameraController;
        private readonly BackgroundController _backgroundController;
        private readonly EnvironmentGenerator _environmentGenerator;
        private readonly BlackHoleBehaviour _blackHoleBehaviour;

        public event Action Initialized;

        public GameplayInitState(
            GameplaySceneContext context, 
            CameraController cameraController, 
            BackgroundController backgroundController)
        {
            _cameraController = cameraController;
            _backgroundController = backgroundController;
            _uiController = context.UIController;
            _environmentGenerator = context.EnvironmentGenerator;
            _blackHoleBehaviour = context.BlackHoleBehaviour;
        }

        public override void Enter()
        {
            YandexPluginGameReadyApiInitializer.Initialize();
            FpsCap.Initialize();
            
            _uiController.Initialize();
            
            _cameraController.SetFollowTarget(_blackHoleBehaviour);
            _backgroundController.SetTarget(_blackHoleBehaviour);
            
            _environmentGenerator.Generate();
            
            Initialized?.Invoke();
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