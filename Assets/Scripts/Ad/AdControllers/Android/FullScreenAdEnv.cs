using CustomTimer;
using UnityEngine;

namespace SourceCode.Ad.AdControllers.Android
{
    public class FullScreenAdEnv : FullScreenAd
    {
        private readonly Timer _adLoadTimer;

        public FullScreenAdEnv(AndroidFullScreenAdEnvConfig config)
        {
            _adLoadTimer = new Timer(config.AdLoadTimer, 0, true);
            _adLoadTimer.OnTimerEnd += ManualFailedShow;
            
            OnAdShowSuccess += OnAdEnded;
            OnAdShowFailed += OnAdEnded;
            OnAdDismissed += OnAdEnded;
            
            OnAdLoaded += OnAdLoad;
            AdLoadFailed -= OnAdLoadFailed;

            TryLoadAd();
        }

        public void ManualUpdate() 
            => _adLoadTimer.Tick(Time.unscaledDeltaTime);

        public void Show()
        {
            if (!AdLoaded)
            {
                Debug.LogWarning("Interstitial is not ready yet");
                OnAdLoaded += Show;
                TryLoadAd();
                return;
            }

            OnAdLoaded -= Show;
            ShowInterstitial();
        }

        private void OnAdEnded() 
            => TryLoadAd();

        private void TryLoadAd()
        {
            _adLoadTimer.Reset();
            RequestToLoadInterstitial();
        }
        
        private void OnAdLoad() 
            => _adLoadTimer.SetPause();

        private void OnAdLoadFailed()
        {
            if (_adLoadTimer.TimerIsEnd)
                return;
            RequestToLoadInterstitial();
        }
    }
}