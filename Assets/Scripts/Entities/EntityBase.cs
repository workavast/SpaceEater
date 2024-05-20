using System;
using CustomTimer;
using UnityEngine;

namespace SourceCode.Entities
{
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class EntityBase : MonoBehaviour
    {
        [SerializeField] private GameObject model;
        [SerializeField] private Animator animator;
        
        private float _colliderRadius;
        private Timer _eatTimer;
        private bool _isConsumed;
        
        public float Size => transform.localScale.x * _colliderRadius;
        protected abstract EatableObjectConfigBase _configBase { get; }
        
        /// <summary>
        /// return size of entity
        /// </summary>
        public event Action<float> ConsumedWithSize;
        public event Action Consumed;
        protected event Action<float> ManualUpdated; 
        
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
                Consumed?.Invoke();
                ConsumedWithSize?.Invoke(Size);
                Destroy(gameObject);
            };
        }

        public void ManualUpdate(float deltaTime)
        {
            _eatTimer.Tick(deltaTime);
            ManualUpdated?.Invoke(deltaTime);
        }

        public void SetAnimationState(bool isActive)
        {
            if (animator != null)
                animator.speed = isActive ? 1 : 0;
        }

        public void SetModelRotation(float modelRotation)
        {
            model.transform.Rotate(Vector3.forward, modelRotation);
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