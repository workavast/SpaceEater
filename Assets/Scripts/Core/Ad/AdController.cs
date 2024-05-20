using System;
using CustomTimer;
using YG;

namespace SourceCode.Core.Ad
{
    public class AdController : IAdTrigger, IAdPreparingTimer
    {
        private readonly Timer _adPreparingTimer;

        public int CurrentPreparingTimerValue { get; private set; }
        
        public event Action AdPreparedTimerUpdated;
        public event Action AdPrepared;
        public event Action AdActivationTriggered;

        public AdController(AdPreparingConfig config)
        {
            _adPreparingTimer = new Timer(config.AdPreparingTime, 0, true);
            _adPreparingTimer.OnTimerEnd += () =>
            {
                _adPreparingTimer.Reset(true);
                AdPrepared?.Invoke();
            };
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
            if (YandexGame.timerShowAd < YandexGame.Instance.infoYG.fullscreenAdInterval)
                return;
            
            _adPreparingTimer.Reset();
            AdActivationTriggered?.Invoke();
        }
    }
}