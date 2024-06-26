using System;
using SourceCode.BackgroundControl;
using SourceCode.CameraMovement;
using SourceCode.Core;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects.EnvironmentGeneration;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayInitState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly CameraController _cameraController;
        private readonly BackgroundController _backgroundController;
        private readonly IEnvironmentGenerator _environmentGenerator;
        private readonly BlackHoleBehaviour _blackHoleBehaviour;
        private readonly SceneLoader _sceneLoader;
        private readonly IEnemiesSpawner _enemiesSpawner;

        public event Action Initialized;

        public GameplayInitState(GameplaySceneContext context, CameraController cameraController, 
            BackgroundController backgroundController)
        {
            _cameraController = cameraController;
            _backgroundController = backgroundController;
            _uiController = context.UIController;
            _environmentGenerator = context.EnvironmentGenerator;
            _blackHoleBehaviour = context.BlackHoleBehaviour;
            _sceneLoader = context.SceneLoader;
            _enemiesSpawner = context.EnemiesSpawner;
        }

        public override void Enter()
        {
#if PLATFORM_WEBGL
            YandexPluginGameReadyApiInitializer.Initialize();
#endif
            FpsCap.Initialize();
            
            _uiController.Initialize();
            
            _cameraController.SetFollowTarget(_blackHoleBehaviour);
            _backgroundController.SetTarget(_blackHoleBehaviour);
            _enemiesSpawner.Init();
            
            _environmentGenerator.Generated += () =>
            {
                _sceneLoader.Init();
                Initialized?.Invoke();
            };
            _environmentGenerator.Generate();
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