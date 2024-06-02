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
        
        public bool IsShowAtTheMoment;
        public bool AdLoaded;
        
        private readonly InterstitialAdLoader _interstitialAdLoader;
        private Interstitial _interstitial;

        //ad loading events
        public event Action OnAdLoaded;
        public event Action AdLoadFailed;
        
        //ad events
        public event Action OnAdShowSuccess;
        public event Action OnAdShowFailed;

        protected FullScreenAd()
        {
            _interstitialAdLoader = new InterstitialAdLoader();
            _interstitialAdLoader.OnAdLoaded += HandleAdLoaded;
            _interstitialAdLoader.OnAdFailedToLoad += HandleAdFailedToLoad;
        }

        public void Dispose()
        {
            _interstitial?.Destroy();
        }
        
        protected void ShowInterstitial()
        {
            if (_interstitial == null)
            {
                // Debug.Log("Interstitial is not ready yet");
                throw new Exception("Interstitial is not ready yet");
                // return;
            }

            _interstitial.OnAdShown += HandleAdShown;
            _interstitial.OnAdFailedToShow += HandleAdFailedToShow;
            _interstitial.OnAdDismissed += HandleAdDismissed;
            IsShowAtTheMoment = true;
            _interstitial.Show();
        }

        protected void RequestToLoadInterstitial()
        {
            //Sets COPPA restriction for user age under 13
            MobileAds.SetAgeRestrictedUser(true);
            
            _interstitial?.Destroy();
            _interstitial = null;
            AdLoaded = false;
            
            _interstitialAdLoader.LoadAd(CreateAdRequest(AdUnitId));
            Debug.Log("Interstitial is requested");
        }
        
        protected void ManualFailedShow()
            => OnAdShowFailed?.Invoke();
        
        private AdRequestConfiguration CreateAdRequest(string adUnitId)
        {
            return new AdRequestConfiguration.Builder(adUnitId).Build();
        }

        private void HandleAdLoaded(object sender, InterstitialAdLoadedEventArgs args)
        {
            Debug.Log("HandleAdLoaded event received");
            
            _interstitial = args.Interstitial;
            AdLoaded = true;
            OnAdLoaded?.Invoke();
        }

        private void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            Debug.Log($"HandleAdFailedToLoad event received with message: {args.Message}");
            
            AdLoadFailed?.Invoke();
        }
        
        private void HandleAdShown(object sender, EventArgs args)
        {
            Debug.Log("HandleAdShown event received");
            
            IsShowAtTheMoment = false;
            OnAdShowSuccess?.Invoke();
        }

        private void HandleAdDismissed(object sender, EventArgs args)
        {
            Debug.Log("HandleAdDismissed event received");

            IsShowAtTheMoment = false;
            _interstitial.Destroy();
            _interstitial = null;
            AdLoaded = false;
        }

        private void HandleAdFailedToShow(object sender, AdFailureEventArgs args)
        {
            Debug.Log($"HandleAdFailedToShow event received with message: {args.Message}");

            IsShowAtTheMoment = false;
            OnAdShowFailed?.Invoke();
        }
    }
}