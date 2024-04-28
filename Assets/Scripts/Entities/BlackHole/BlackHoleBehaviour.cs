using System;
using System.Collections.Generic;
using SourceCode.BackgroundControl;
using SourceCode.Core;
using SourceCode.Core.PlayZone;
using SourceCode.Core.TriggerZone;
using SourceCode.InputDetectors;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SourceCode.Entities.BlackHole
{
    public class BlackHoleBehaviour : EntityBase, ICameraTarget, IBackgroundTarget
    {
        [SerializeField] private TriggerZone2D triggerZone2D;
        
        [Inject] private readonly PlayZoneConfig _playZoneConfig;
        [Inject] private readonly BlackHoleConfig _config;
        
        private InputDetectorBase _inputDetector;
        private readonly List<EntityBase> _eatableObjects = new(2);

        public Transform Transform => transform;
        protected override EatableObjectConfigBase _configBase => _config;

        public event Action OnUpdateSize;
        /// <summary>
        /// return direction and distance of move
        /// </summary>
        public event Action<Vector2, float> OnMove;
        
        protected override void Awake()
        {
            base.Awake();

            var modelRotation = Random.Range(-_config.ModelRotation, _config.ModelRotation);
            SetModelRotation(modelRotation);
            
            _inputDetector = new DesktopInput();

            triggerZone2D.OnEnter += EatableObjectEnter;
            triggerZone2D.OnExit += EatableObjectExit;
        }

        private void Update()
        {
            _inputDetector.ManualUpdate();
            ManualUpdate(Time.deltaTime);
            Move(Time.deltaTime);
        }

        private void Move(float time)
        {
            var direction = _inputDetector.MoveDirection;
            if(direction == Vector2.zero)
                return;
            var distance = Size * _config.MoveSpeed * time;

            var expectPosition = (Vector2)transform.position + direction * distance;
            if (!expectPosition.PointInCircle(Vector2.zero, _playZoneConfig.Radius))
            {
                var clampPosition = expectPosition.ClampInCircle(Vector2.zero, _playZoneConfig.Radius);
                
                direction = (clampPosition - (Vector2)transform.position).normalized;
                distance = Vector2.Distance(clampPosition, transform.position);
            }
            
            transform.Translate(direction * distance);
            OnMove?.Invoke(direction, distance);
        }

        private void EatableObjectEnter(Collider2D other)
        {
            if (!other.TryGetComponent(out EntityBase staticEatableObject))
                return;
            
            if (_eatableObjects.Contains(staticEatableObject))
            {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                Debug.LogWarning($"Attention! Second enter");
#endif
                return;
            }
            
            if(staticEatableObject.Size > Size)
                return;
            
            staticEatableObject.OnConsumedWithSize += IncreaseSize;
            staticEatableObject.StartEat();
            _eatableObjects.Add(staticEatableObject);
        }

        private void EatableObjectExit(Collider2D other)
        {
            if (!other.TryGetComponent(out EntityBase staticEatableObject))
                return;
            
            if (!_eatableObjects.Contains(staticEatableObject))
                return;

            staticEatableObject.OnConsumedWithSize -= IncreaseSize;
            staticEatableObject.StopEat();
            _eatableObjects.Remove(staticEatableObject);
        }

        private void IncreaseSize(float eatenSize)
        {
            transform.localScale += Vector3.one * (eatenSize * _config.IncreaseScale);
            OnUpdateSize?.Invoke();
        }
    }
}