using System;
using SourceCode.Ad.AdControllers;
using SourceCode.Ad.Preparing;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;
using UnityEngine;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayAdShowState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly IAdPreparingTimer _adPreparingTimer;
        private readonly IFullScreenAd _fullScreenAd;
        
        public event Action AdShowEnded;
        
        public GameplayAdShowState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
            _adPreparingTimer = context.AdPreparingTimer;
            _fullScreenAd = context.FullScreenAd;

            _adPreparingTimer.AdPrepared += _fullScreenAd.ShowFullScreen;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayAdShowScreen>();
            _adPreparingTimer.ManualUpdate(0);
            _fullScreenAd.FullScreenAdShowed += OnAdFullScreenShowed;
            _fullScreenAd.FullScreenShowAdFailed += OnAdFullScreenShowed;
        }

        public override void Exit()
        {
            _fullScreenAd.FullScreenAdShowed -= OnAdFullScreenShowed;
            _fullScreenAd.FullScreenShowAdFailed -= OnAdFullScreenShowed;
        }

        public override void ManualUpdate()
        {
            _adPreparingTimer.ManualUpdate(Time.deltaTime);
        }

        public override void ManualFixedUpdate()
        {
            
        }

        private void OnAdFullScreenShowed()
        {
            AdShowEnded?.Invoke();
        }
    }
}