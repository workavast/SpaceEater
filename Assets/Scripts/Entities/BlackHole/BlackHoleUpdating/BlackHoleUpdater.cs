using UnityEngine;

namespace SourceCode.Entities.BlackHole.BlackHoleUpdating
{
    public class BlackHoleUpdater : IBlackHoleUpdater
    {
        private readonly BlackHoleBehaviour _blackHoleBehaviour;

        public bool PlayerIsAlive => _blackHoleBehaviour.IsAlive;

        public BlackHoleUpdater(BlackHoleBehaviour blackHoleBehaviour)
        {
            _blackHoleBehaviour = blackHoleBehaviour;
        }

        public void ManualUpdate()
        {
            if(PlayerIsAlive)
                _blackHoleBehaviour.ManualUpdate(Time.deltaTime);    
        }
    }
}