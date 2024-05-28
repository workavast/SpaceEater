using UnityEngine;

namespace SourceCode.Entities.BlackHole.BlackHoleUpdating
{
    public class BlackHoleUpdater : IBlackHoleUpdater
    {
        private readonly BlackHoleBehaviour _blackHoleBehaviour;

        public bool PlayerIsAlive { get; private set; } = true;

        public BlackHoleUpdater(BlackHoleBehaviour blackHoleBehaviour)
        {
            _blackHoleBehaviour = blackHoleBehaviour;
            blackHoleBehaviour.Consumed += () => PlayerIsAlive = false;
        }

        public void ManualUpdate()
        {
            if(PlayerIsAlive)
                _blackHoleBehaviour.ManualUpdate(Time.deltaTime);    
        }
    }
}