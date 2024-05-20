using System;

namespace SourceCode.Core.Ad
{
    public interface IAdPreparingTimer
    {
        public event Action AdPrepared;
        public event Action AdPreparedTimerUpdated;
        
        public int CurrentPreparingTimerValue { get; }

        public void ManualUpdate(float deltaTime);
    }
}