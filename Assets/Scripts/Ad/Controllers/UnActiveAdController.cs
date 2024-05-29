using System;

namespace SourceCode.Ad.Controllers
{
    public class UnActiveAdController: IAdTrigger, IAdTriggerActivator, IAdPreparingTimer
    {
        public int CurrentPreparingTimerValue { get; private set; }
        
        public event Action AdPreparedTimerUpdated;
        public event Action AdPrepared;
        public event Action AdActivationTriggered;
        
        public void ManualUpdate(float deltaTime)
        {
        }

        public void TryActivateFullScreenAd()
        {
        }
    }
}