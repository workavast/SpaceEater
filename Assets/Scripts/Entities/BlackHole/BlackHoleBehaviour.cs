using System;
using System.Collections.Generic;
using SourceCode.BackgroundControl;
using SourceCode.Core;
using SourceCode.Entities.EatableObject;
using SourceCode.InputDetectors;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.BlackHole
{
    public class BlackHoleBehaviour : EntityBase, ICameraTarget, IBackgroundTarget
    {
        [Inject] private readonly BlackHoleConfig _config;
        
        private InputDetectorBase _inputDetector;
        
        private readonly List<EatableObjectBehaviour> _eatableObjects = new(2);

        public Transform Transform => transform;
        
        public event Action OnUpdateSize;
        public event Action<Vector2, float> OnMove;

        protected override void Awake()
        {
            base.Awake();
            
            _inputDetector = new DesktopInput();
        }

        private void Update()
        {
            _inputDetector.ManualUpdate();
            Move(Time.deltaTime);
        }

        private void Move(float time)
        {
            var direction = _inputDetector.MoveDirection;
            if(direction == Vector2.zero)
                return;
            var distance = Size * _config.MoveSpeed * time;
            transform.Translate(direction * distance);
            OnMove?.Invoke(direction, distance);
        }

        private void EatableObjectEnter(EatableObjectBehaviour eatableObjectBehaviour)
        {
            if (_eatableObjects.Contains(eatableObjectBehaviour))
            {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                Debug.LogWarning($"Attention! Second enter");
#endif
                return;
            }
            
            if(eatableObjectBehaviour.Size > Size)
                return;
            
            eatableObjectBehaviour.StartEat();
            eatableObjectBehaviour.OnEaten += IncreaseSize;
            _eatableObjects.Add(eatableObjectBehaviour);
        }

        private void EatableObjectExit(EatableObjectBehaviour eatableObjectBehaviour)
        {
            if (!_eatableObjects.Contains(eatableObjectBehaviour))
                return;

            eatableObjectBehaviour.OnEaten -= IncreaseSize;
            eatableObjectBehaviour.StopEat();
            _eatableObjects.Remove(eatableObjectBehaviour);
        }

        private void IncreaseSize(float eatenSize)
        {
            transform.localScale += Vector3.one * eatenSize * _config.IncreaseScale;
            OnUpdateSize?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EatableObjectBehaviour eatableObjectBehaviour))
                EatableObjectEnter(eatableObjectBehaviour);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out EatableObjectBehaviour eatableObjectBehaviour))
                EatableObjectExit(eatableObjectBehaviour);
        }
    }
}