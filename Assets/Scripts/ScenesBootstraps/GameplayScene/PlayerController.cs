using SourceCode.Entities.BlackHole;
using UnityEngine;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class PlayerController
    {
        private readonly BlackHoleBehaviour _blackHoleBehaviour;

        public bool PlayerIsAlive { get; private set; } = true;

        public PlayerController(BlackHoleBehaviour blackHoleBehaviour)
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