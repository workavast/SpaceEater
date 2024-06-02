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
            _adLoadTimer.OnTimerEnd += OnAdLoadTimerEnd;
            
            RequestToLoadInterstitial();
        }

        public void ManualUpdate()
        {
            _adLoadTimer.Tick(Time.unscaledDeltaTime);
        }
        
        public void Show()
        {
            Debug.Log("---- Try show");
            if (!AdLoaded)
            {
                Debug.Log("Interstitial is not ready yet");
                OnAdLoaded += Show;
                AdLoadFailed += OnAdLoadFailed;
                RequestToLoadInterstitial();
                return;
            }

            ShowInterstitial();
        }

        private void OnAdLoadSuccess() 
            => RequestToLoadInterstitial();
        
        private void OnAdLoadFailed()
            => RequestToLoadInterstitial();

        private void OnAdLoadTimerEnd()
        {
            OnAdLoaded -= Show;
            AdLoadFailed -= OnAdLoadFailed;
            ManualFailedShow();
        }
    }
}