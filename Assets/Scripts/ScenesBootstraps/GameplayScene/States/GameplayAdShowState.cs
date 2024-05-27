using System;
using SourceCode.Ad;
using SourceCode.ScenesBootstraps.GameplayScene.Context;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;
using UnityEngine;
using YG;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayAdShowState : GameStateBase
    {
        private readonly UI_Controller _uiController;
        private readonly GameplayAdShowScreen _gameplayAdShowScreen;
        private readonly IAdPreparingTimer _adPreparingTimer;
        
        public event Action AdShowEnded;
        
        public GameplayAdShowState(GameplaySceneContext context)
        {
            _uiController = context.UIController;
            _adPreparingTimer = context.AdPreparingTimer;
            _gameplayAdShowScreen = UI_ScreenRepository.GetScreen<GameplayAdShowScreen>();

            _adPreparingTimer.AdPrepared += YandexGame.FullscreenShow;
        }
        
        public override void Enter()
        {
            _uiController.SetScreen<GameplayAdShowScreen>();
            YandexGame.CloseFullAdEvent += OnAdShowed;
            YandexGame.ErrorFullAdEvent += OnAdShowed;
        }

        public override void Exit()
        {
            YandexGame.CloseFullAdEvent -= OnAdShowed;
            YandexGame.ErrorFullAdEvent -= OnAdShowed;
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