using System;
using CustomTimer;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.EatableObject
{
    public class EatableObjectBehaviour : EntityBase
    {
        [SerializeField] private EatableObjectType eatableObjectType;
        [Inject] private readonly EatableItemConfig _config;

        public EatableObjectType EatableObjectType => eatableObjectType;
        private Timer _eatTimer;
        private bool _isConsumed;
        
        /// <summary>
        /// return size of entity
        /// </summary>
        public event Action<float> OnEaten;
        public event Action<EatableObjectBehaviour> OnRemove;

        protected override void Awake()
        {
            base.Awake();
            
            _eatTimer = new Timer(_config.EatTime, 0, true);
            _eatTimer.OnTimerEnd += () =>
            {
                OnEaten?.Invoke(Size);
                OnRemove?.Invoke(this);
                Destroy(gameObject);
            };
        }

        public void ManualUpdate(float time)
        {
            _eatTimer.Tick(time);
        }

        public void StartEat()
        {
            if (_isConsumed)
            {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                Debug.LogWarning($"Attention! Second enter");
#endif
                return;
            }

            _isConsumed = true;
            _eatTimer.Reset();
        }

        public void StopEat()
        {
            _isConsumed = false;
            _eatTimer.SetPause();
        }
    }
}