using System;
using SourceCode.Core;
using SourceCode.Entities.BlackHole;
using SourceCode.PlayZone;
using SourceCode.TriggerZone;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.Enemies
{
    public class Enemy : EntityBase
    {
        [SerializeField] private TriggerZone2D triggerZone;
        
        private PlayZoneConfig _playZoneConfig;
        private EnemiesConfig _config;
        private Vector2 _moveDirection;

        protected override EatableObjectConfigBase _configBase => _config;

        public event Action<Enemy> OnRemove;

        [Inject]
        public void Construct(PlayZoneConfig playZoneConfig, EnemiesConfig config)
        {
            _playZoneConfig = playZoneConfig;
            _config = config;
        }
        
        protected override void Awake()
        {
            base.Awake();

            ManualUpdated += Move;

            triggerZone.OnEnter += PlayerEnter;
            triggerZone.OnExit += PlayerExit;
            
            Consumed += () => { OnRemove?.Invoke(this); };
        }

        // private void Update()
        // {
        //     ManualUpdate(Time.deltaTime);
        // }

        public void Initialize(Vector2 newMoveDirection, float modelRotation)
        {
            _moveDirection = newMoveDirection;
            SetModelRotation(modelRotation);
        }
        
        private void Move(float deltaTime)
        {
            var direction = _moveDirection;

            var distance = Size * _config.MoveSpeed * deltaTime;

            var expectPosition = (Vector2)transform.position + direction * distance;
            if (!expectPosition.PointInCircle(Vector2.zero, _playZoneConfig.Radius))
                _moveDirection = direction = -direction;
            
            transform.Translate(direction * distance);
        }

        private void PlayerEnter(Collider2D other)
        {
            if(!other.gameObject.TryGetComponent(out BlackHoleBehaviour player))
                return;
            
            if(player.Size > Size)
                return;
            
            player.StartEat();
        }

        private void PlayerExit(Collider2D other)
        {
            if(!other.gameObject.TryGetComponent(out BlackHoleBehaviour player))
                return;
            
            player.StopEat();
        }
    }
}