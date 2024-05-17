using System;
using SourceCode.ScenesBootstraps.SceneFSM;
using SourceCode.Ui;

namespace SourceCode.ScenesBootstraps.GameplayScene.States
{
    public class GameplayLoadingScreenFadeState : GameStateBase
    {
        public event Action FadeEnded;
        
        public override void Enter()
        {
            if (LoadingScreen.Instance.IsShow)
                LoadingScreen.Instance.FadeAnimationEnded += OnLoadScreenFadeEnd;
            else
                OnLoadScreenFadeEnd();
        }

        private void OnLoadScreenFadeEnd()
        {
            LoadingScreen.Instance.FadeAnimationEnded -= OnLoadScreenFadeEnd;
            FadeEnded?.Invoke();
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