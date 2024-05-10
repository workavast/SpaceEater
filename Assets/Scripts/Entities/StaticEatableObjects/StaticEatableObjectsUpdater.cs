using System.Collections.Generic;
using GameCycleFramework;
using SourceCode.Entities.StaticEatableObjects.Factory;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects
{
    public class StaticEatableObjectsUpdater
    {
        private readonly StaticEatableObjectsFactory _factory;
        private readonly List<StaticEatableObject> _eatableObjects = new();

        public StaticEatableObjectsUpdater(StaticEatableObjectsFactory factory)
        {
            _factory = factory;
            _factory.OnCreate += Add;
        }

        public void ManualUpdate()
        {
            var time = Time.deltaTime;
            for (int i = 0; i < _eatableObjects.Count; i++)
                _eatableObjects[i].ManualUpdate(time);
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
            _eatableObjects.Remove(staticEatableObject);
        }
    }
}