using System;
using CustomTimer;
using SourceCode.Ad.AdControllers;

namespace SourceCode.Ad.Preparing
{
    public sealed class AdPreparer : IAdPreparedTrigger, IAdPreparingTimer, IAdTriggerActivator
    {
        private readonly IAdTimer _adTimer;
        private readonly IFullScreenAd _fullScreenAd;
        private readonly Timer _adPreparingTimer;

        public int CurrentPreparingTimerValue { get; private set; }
        
        public event Action AdPreparingTriggered;
        public event Action AdPrepared;
        public event Action AdPreparedTimerUpdated;
        
        public AdPreparer(AdPreparingConfig config, IAdTimer adTimer, IFullScreenAd fullScreenAd)
        {
            _adTimer = adTimer;
            _fullScreenAd = fullScreenAd;
            _adPreparingTimer = new Timer(config.AdPreparingTime, 0, true);
            _adPreparingTimer.OnTimerEnd += () => AdPrepared?.Invoke();
        }
        
        public void ManualUpdate(float deltaTime) 
            => UpdatePreparingTimer(deltaTime);

        private void UpdatePreparingTimer(float deltaTime)
        {
            _adPreparingTimer.Tick(deltaTime);
            var newCurTime = (int)Math.Ceiling(_adPreparingTimer.MaxTime - _adPreparingTimer.CurrentTime);
            if (newCurTime != CurrentPreparingTimerValue)
            {
                CurrentPreparingTimerValue = newCurTime;
                AdPreparedTimerUpdated?.Invoke();
            }
        }
        
        public void TryActivateFullScreenAd()
        {
            if (!_adTimer.AdReady)
                return;
            
            _fullScreenAd.PrepareAd();
            _adPreparingTimer.Reset();
            AdPreparingTriggered?.Invoke();
        }
    }
}