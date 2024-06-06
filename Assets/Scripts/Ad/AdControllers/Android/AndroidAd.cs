using System;
using CustomTimer;
using UnityEngine;
using Zenject;

namespace SourceCode.Ad.AdControllers.Android
{
    public sealed class AndroidAd : MainAdControllerBase , ITickable, IDisposable
    {
        private readonly FullScreenAdEnv _fullScreenAdEnv;
        private readonly Timer _adTimer;

        public override bool AdReady => _adTimer.CurrentTime >= _adTimer.MaxTime;
        
        public override event Action FullScreenAdShowed;
        public override event Action FullScreenShowAdFailed;
        
        public AndroidAd(AndroidFullScreenAdEnvConfig androidFullScreenAdEnvConfig)
        {
            _adTimer = new Timer(androidFullScreenAdEnvConfig.TimerBeforeAdShow);
            _fullScreenAdEnv = new FullScreenAdEnv(androidFullScreenAdEnvConfig);

            _fullScreenAdEnv.OnAdShowSuccess += () =>
            {
                _adTimer.Reset();
                FullScreenAdShowed?.Invoke();
            };
            _fullScreenAdEnv.OnAdShowFailed += () =>
            {
                _adTimer.Reset();
                FullScreenShowAdFailed?.Invoke();
            };
            _fullScreenAdEnv.OnAdDismissed += () =>
            {
                _adTimer.Reset();
                FullScreenShowAdFailed?.Invoke();
            };
        }

        public void Tick()
        {
            if (!_fullScreenAdEnv.IsShowAtTheMoment)
                _adTimer.Tick(Time.unscaledDeltaTime);
            
            _fullScreenAdEnv.ManualUpdate();
        }
        
        public void Dispose()
        {
            _fullScreenAdEnv?.Dispose();
        }

        public override void PrepareAd()
        {
            _fullScreenAdEnv.Prepare();
        }

        public override void ShowFullScreen()
        {
            if(_fullScreenAdEnv.IsShowAtTheMoment)
            {
                Debug.LogError($"-AD- Ad show at the moment");
                FullScreenShowAdFailed?.Invoke();
                return;
            }
            
            if(!AdReady)
            {
                Debug.LogError($"-AD- Ad timer dont ready");
                FullScreenShowAdFailed?.Invoke();
                return;
            }
            
            _fullScreenAdEnv.Show();
        }
    }
}