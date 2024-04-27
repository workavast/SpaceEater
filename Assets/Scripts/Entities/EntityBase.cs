using System;
using CustomTimer;
using UnityEngine;

namespace SourceCode.Entities
{
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class EntityBase : MonoBehaviour
    {
        private float _colliderRadius;
        private Timer _eatTimer;
        private bool _isConsumed;
        
        public float Size => transform.localScale.x * _colliderRadius;
        protected abstract EatableObjectConfigBase _configBase { get; }
        
        /// <summary>
        /// return size of entity
        /// </summary>
        public event Action<float> OnConsumedWithSize;
        public event Action OnConsumed;
        protected event Action<float> OnManualUpdate; 
        
        protected virtual void Awake()
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (Math.Abs(transform.localScale.x - transform.localScale.y) > 0.01f)
                Debug.LogWarning($"Attention! Scales of object ({gameObject.name}) dont equal: {transform.localScale}");
#endif
            
            _colliderRadius = GetComponent<CircleCollider2D>().radius;
            
            
            _eatTimer = new Timer(_configBase.EatTime, 0, true);
            _eatTimer.OnTimerEnd += () =>
            {
                OnConsumed?.Invoke();
                OnConsumedWithSize?.Invoke(Size);
                Destroy(gameObject);
            };
        }

        public void ManualUpdate(float deltaTime)
        {
            _eatTimer.Tick(deltaTime);
            OnManualUpdate?.Invoke(deltaTime);
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