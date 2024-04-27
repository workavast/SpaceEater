using System.Collections.Generic;
using GameCycleFramework;
using SourceCode.Entities.StaticEatableObjects.Factory;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects
{
    public class StaticEatableObjectsUpdater : IGameCycleUpdate
    {
        private readonly StaticEatableObjectsFactory _factory;
        private readonly List<StaticEatableObject> _eatableObjects = new();

        public StaticEatableObjectsUpdater(IGameCycleController gameCycleController, StaticEatableObjectsFactory factory)
        {
            _factory = factory;
            gameCycleController.AddListener(GameCycleState.Gameplay, this);
            _factory.OnCreate += Add;
        }

        public void GameCycleUpdate()
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