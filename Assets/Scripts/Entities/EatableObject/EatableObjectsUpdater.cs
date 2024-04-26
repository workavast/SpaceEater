using System.Collections.Generic;
using GameCycleFramework;
using SourceCode.Entities.EatableObject.Factory;
using UnityEngine;

namespace SourceCode.Entities.EatableObject
{
    public class EatableObjectsUpdater : IGameCycleUpdate
    {
        private readonly List<EatableObjectBehaviour> _eatableObjects = new();

        public EatableObjectsUpdater(IGameCycleController gameCycleController, EatableObjectsFactory eatableObjectsFactory)
        {
            gameCycleController.AddListener(GameCycleState.Gameplay, this);
            eatableObjectsFactory.OnCreate += Add;
        }

        public void GameCycleUpdate()
        {
            var time = Time.deltaTime;
            for (int i = 0; i < _eatableObjects.Count; i++)
                _eatableObjects[i].ManualUpdate(time);
        }

        private void Add(EatableObjectBehaviour eatableObject)
        {
            if(_eatableObjects.Contains(eatableObject))
                Debug.LogError($"Duplicate of {eatableObject} with type {eatableObject.EatableObjectType}");
            else
            {
                eatableObject.OnRemove += Remove;
                _eatableObjects.Add(eatableObject);
            }
        }

        private void Remove(EatableObjectBehaviour eatableObject)
        {
            _eatableObjects.Remove(eatableObject);
        }
    }
}