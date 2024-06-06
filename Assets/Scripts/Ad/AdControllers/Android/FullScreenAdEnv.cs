using CustomTimer;
using SomeStorages;
using UnityEngine;

namespace SourceCode.Ad.AdControllers.Android
{
    public class FullScreenAdEnv : FullScreenAd
    {
        private readonly Timer _adLoadTimer;
        private readonly SomeStorageInt _adLoadCounter;
        private bool _isShowRequest;
        private bool _isAdLoading;
        
        public FullScreenAdEnv(AndroidFullScreenAdEnvConfig config)
        {
            _adLoadCounter = new SomeStorageInt(5);
            _adLoadTimer = new Timer(config.AdLoadTimer, 0, true);
            
            OnAdShowSuccess += OnAdEnded;
            OnAdShowFailed += OnAdEnded;
            OnAdDismissed += OnAdEnded;

            OnAdLoaded += OnAdLoad;
            AdLoadFailed += OnAdLoadFailed;

            TryLoadAd();
        }

        public void ManualUpdate() 
            => _adLoadTimer.Tick(Time.unscaledDeltaTime);

        public void Prepare()
        {
            if(AdLoaded || _isAdLoading)
                return;
            
            TryLoadAd();
        }
        
        public void Show()
        {
            if (!AdLoaded)
            {
                _isShowRequest = true;
                Debug.LogWarning("-AD- Interstitial is not ready yet");
                if(!_isAdLoading)
                    TryLoadAd();
                return;
            }

            _isShowRequest = false;
            ShowInterstitial();
        }

        private void OnAdEnded() 
            => TryLoadAd();

        private void TryLoadAd()
        {
            _isAdLoading = true;
            _adLoadCounter.SetCurrentValue(0);
            _adLoadTimer.Reset();
            RequestToLoadInterstitial();
        }
        
        private void OnAdLoad()
        {
            _isAdLoading = false;
            _adLoadTimer.SetPause();
            if(_isShowRequest)
                Show();
        }

        private void OnAdLoadFailed()
        {
            _adLoadCounter.ChangeCurrentValue(1);
            if (_adLoadTimer.TimerIsEnd || _adLoadCounter.IsFull)
            {
                _isAdLoading = false;
                if (_isShowRequest)
                {
                    _isShowRequest = false;
                    ManualShowFailed();
                }
                return;
            }
            RequestToLoadInterstitial();
        }
    }
}