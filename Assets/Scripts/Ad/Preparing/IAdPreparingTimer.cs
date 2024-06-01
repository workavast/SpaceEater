using System;

namespace SourceCode.Ad.Preparing
{
    public interface IAdPreparingTimer
    {
        public event Action AdPrepared;
        public event Action AdPreparedTimerUpdated;
        
        public int CurrentPreparingTimerValue { get; }

        public void ManualUpdate(float deltaTime);
    }
}