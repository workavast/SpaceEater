using SourceCode.Entities;
using UnityEngine;

namespace SourceCode.Bootstraps.GameplayScene
{
    public class PlayerController
    {
        private readonly EntityBase _entity;

        public bool PlayerIsAlive { get; private set; } = true;

        public PlayerController(EntityBase entity)
        {
            _entity = entity;
            entity.OnConsumed += () => PlayerIsAlive = false;
        }

        public void ManualUpdate()
        {
            if(PlayerIsAlive)
                _entity.ManualUpdate(Time.deltaTime);    
        }
    }
}