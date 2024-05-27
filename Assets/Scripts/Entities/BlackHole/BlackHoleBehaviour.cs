using System;
using System.Collections.Generic;
using EventBusFramework;
using SourceCode.Audio.AudioSources;
using SourceCode.BackgroundControl;
using SourceCode.CameraMovement;
using SourceCode.Core;
using SourceCode.InputDetection;
using SourceCode.PlayZone;
using SourceCode.ScenesBootstraps.GameplayScene.EndGameDetection;
using SourceCode.TriggerZone;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SourceCode.Entities.BlackHole
{
    public class BlackHoleBehaviour : EntityBase, ICameraTarget, IBackgroundTarget, IEndGameDetectionTarget
    {
        [SerializeField] private TriggerZone2D triggerZone2D;
        
        [Inject] private readonly PlayZoneConfig _playZoneConfig;
        [Inject] private readonly BlackHoleConfig _config;
        [Inject] private readonly IInputDetector _inputDetector;
        [Inject] private readonly EventBus _eventBus;
        
        private readonly List<EntityBase> _eatableObjects = new(2);
        private BlackHoleSizeUpdater _blackHoleSizeUpdater;
        
        public float TargetSize { get; private set; }
        public Transform Transform => transform;
        protected override EatableObjectConfigBase _configBase => _config;

        public event Action OnUpdateTargetSize;
        /// <summary>
        /// return direction and distance of move
        /// </summary>
        public event Action<Vector2, float> OnMove;
        
        protected override void Awake()
        {
            base.Awake();
            TargetSize = Size;
            var modelRotation = Random.Range(-_config.ModelRotation, _config.ModelRotation);
            SetModelRotation(modelRotation);
            
            triggerZone2D.OnEnter += EatableObjectEnter;
            triggerZone2D.OnExit += EatableObjectExit;

            ManualUpdated += deltaTime => _inputDetector.ManualUpdate();
            ManualUpdated += Move;

            _blackHoleSizeUpdater = new BlackHoleSizeUpdater(this, _config);
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
            
            staticEatableObject.Consumed += OnConsumeObject;
            staticEatableObject.ConsumedWithSize += UpdateSize;
            staticEatableObject.StartEat();
            _eatableObjects.Add(staticEatableObject);
        }

        private void EatableObjectExit(Collider2D other)
        {
            if (!other.TryGetComponent(out EntityBase staticEatableObject))
                return;
            
            if (!_eatableObjects.Contains(staticEatableObject))
                return;

            staticEatableObject.Consumed -= OnConsumeObject;
            staticEatableObject.ConsumedWithSize -= UpdateSize;
            staticEatableObject.StopEat();
            _eatableObjects.Remove(staticEatableObject);
        }

        private void OnConsumeObject()
        {
            _eventBus.Invoke(new ObjectConsumed());
        }
        
        private void UpdateSize(float eatenSize)
        {
            if (transform.localScale.x > TargetSize)
                TargetSize = transform.localScale.x;
                
            TargetSize += eatenSize * _config.IncreaseScale;
            OnUpdateTargetSize?.Invoke();
            _blackHoleSizeUpdater.IncreaseSize();
        }
    }
}