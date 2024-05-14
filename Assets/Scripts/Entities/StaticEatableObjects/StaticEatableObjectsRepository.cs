using System;
using System.Collections.Generic;
using SourceCode.Entities.StaticEatableObjects.Factory;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects
{
    public class StaticEatableObjectsRepository
    {
        private readonly StaticEatableObjectsFactory _factory;
        private readonly List<StaticEatableObject> _eatableObjects = new();

        public IReadOnlyList<StaticEatableObject> EatableObjects => _eatableObjects;

        public event Action<StaticEatableObject> RemovedEatableObjects;
        
        public StaticEatableObjectsRepository(StaticEatableObjectsFactory factory)
        {
            _factory = factory;
            _factory.OnCreate += Add;
        }

        private void Add(StaticEatableObject staticEatableObject)
        {
            if(_eatableObjects.Contains(staticEatableObject))
                Debug.LogError($"Duplicate of {staticEatableObject} with type {staticEatableObject.StaticEatableObjectType}");
            else
            {
                staticEatableObject.OnRemoveStaticEatableObject += Remove;
                _eatableObjects.Add(staticEatableObject);
            }
        }

        private void Remove(StaticEatableObject staticEatableObject)
        {
            if (_eatableObjects.Remove(staticEatableObject))
                RemovedEatableObjects?.Invoke(staticEatableObject);
        }
    }
}