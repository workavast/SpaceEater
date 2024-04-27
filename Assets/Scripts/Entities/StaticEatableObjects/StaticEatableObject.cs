using System;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.StaticEatableObjects
{
    public class StaticEatableObject : EntityBase
    {
        [SerializeField] private StaticEatableObjectType staticEatableObjectType;
        
        [Inject] private readonly StaticEatableObjectConfig _config;

        protected override EatableObjectConfigBase _configBase => _config;
        public StaticEatableObjectType StaticEatableObjectType => staticEatableObjectType;

        public event Action<StaticEatableObject> OnRemoveStaticEatableObject;
        
        protected override void Awake()
        {
            base.Awake();

            OnConsumed += RemoveStaticEatableObject;
        }

        private void RemoveStaticEatableObject()
            => OnRemoveStaticEatableObject?.Invoke(this);
    }
}