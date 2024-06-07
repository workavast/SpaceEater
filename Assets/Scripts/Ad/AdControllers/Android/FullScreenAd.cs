using System;
using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

namespace SourceCode.Ad.AdControllers.Android
{
    public abstract class FullScreenAd : IDisposable
    {
        // Replace demo Unit ID 'demo-interstitial-yandex' with actual Ad Unit ID
        private const string AdUnitId = "demo-interstitial-yandex";
        private const string AdUnitIdMain = "R-M-9084369-1";
        
        public bool IsShowAtTheMoment { get; private set; }
        public bool AdLoaded { get; private set; }
        
        private readonly InterstitialAdLoader _interstitialAdLoader;
        private Interstitial _interstitial;

        //ad loading events
        public event Action OnAdLoaded;
        public event Action AdLoadFailed;
        
        //ad events
        public event Action OnAdShowSuccess;
        public event Action OnAdShowFailed;
        public event Action OnAdDismissed;

        protected FullScreenAd()
        {
            _interstitialAdLoader = new InterstitialAdLoader();
            _interstitialAdLoader.OnAdLoaded += HandleAdLoaded;
            _interstitialAdLoader.OnAdFailedToLoad += HandleAdFailedToLoad;
        }

        public void Dispose()
        {
            _interstitial?.Destroy();
            _interstitialAdLoader.CancelLoading();
        }
        
        protected void ShowInterstitial()
        {
            if (_interstitial == null)
            {
                Debug.LogError("-AD- Interstitial is not ready yet");
                OnAdShowFailed?.Invoke();
                return;
            }

            _interstitial.OnAdShown += HandleAdShown;
            _interstitial.OnAdFailedToShow += HandleAdFailedToShow;
            _interstitial.OnAdDismissed += HandleAdDismissed;
            IsShowAtTheMoment = true;
            AdLoaded = false;
            _interstitial.Show();
        }

        protected void RequestToLoadInterstitial()
        {
            //Sets COPPA restriction for user age under 13
            MobileAds.SetAgeRestrictedUser(true);
            
            _interstitial?.Destroy();
            _interstitial = null;
            AdLoaded = false;
            
            _interstitialAdLoader.CancelLoading();
            _interstitialAdLoader.LoadAd(CreateAdRequest(AdUnitIdMain));
            Debug.Log("-AD- Interstitial is requested");
        }
        
        protected void ManualShowFailed()
        {
            Debug.Log($"-AD- ManualFailedShow event received");
            IsShowAtTheMoment = false;
            OnAdShowFailed?.Invoke();
        }

        private AdRequestConfiguration CreateAdRequest(string adUnitId)
        {
            return new AdRequestConfiguration.Builder(adUnitId).Build();
        }

        private void HandleAdLoaded(object sender, InterstitialAdLoadedEventArgs args)
        {
            Debug.Log("-AD- HandleAdLoaded event received");
            
            _interstitial = args.Interstitial;
            AdLoaded = true;
            OnAdLoaded?.Invoke();
        }

        private void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            Debug.Log($"-AD- HandleAdFailedToLoad event received with message: {args.Message}");
            
            AdLoaded = false;
            AdLoadFailed?.Invoke();
        }
        
        private void HandleAdShown(object sender, EventArgs args)
        {
            Debug.Log("-AD- HandleAdShown event received");
            
            IsShowAtTheMoment = false;
            _interstitial?.Destroy();
            _interstitial = null;
            OnAdShowSuccess?.Invoke();
        }

        private void HandleAdDismissed(object sender, EventArgs args)
        {
            Debug.Log("-AD- HandleAdDismissed event received");

            IsShowAtTheMoment = false;
            _interstitial?.Destroy();
            _interstitial = null;
            OnAdDismissed?.Invoke();
        }

        private void HandleAdFailedToShow(object sender, AdFailureEventArgs args)
        {
            Debug.Log($"-AD- HandleAdFailedToShow event received with message: {args.Message}");

            IsShowAtTheMoment = false;
            _interstitial?.Destroy();
            _interstitial = null;
            OnAdShowFailed?.Invoke();
        }
    }
}