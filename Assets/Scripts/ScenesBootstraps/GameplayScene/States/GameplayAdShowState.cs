using System;
using SourceCode.Ad;
using SourceCode.Ad.FullScreenAd;
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
        private readonly IFullScreenAd _fullScreenAd = new YandexGamesFullScreenAd();
        
        public event Action AdShowEnded;
        
        public GameplayAdShowState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
            _adPreparingTimer = context.AdPreparingTimer;

            _adPreparingTimer.AdPrepared += _fullScreenAd.Show;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayAdShowScreen>();
            _fullScreenAd.Showed += OnAdShowed;
            _fullScreenAd.OnError += OnAdShowed;
        }

        public override void Exit()
        {
            _fullScreenAd.Showed -= OnAdShowed;
            _fullScreenAd.OnError -= OnAdShowed;
        }

        public override void ManualUpdate()
        {
            _adPreparingTimer.ManualUpdate(Time.deltaTime);
        }

        public override void ManualFixedUpdate()
        {
            
        }

        private void OnAdShowed()
        {
            AdShowEnded?.Invoke();
        }
    }
}