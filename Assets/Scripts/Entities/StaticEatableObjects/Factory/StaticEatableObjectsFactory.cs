using System;
using System.Collections.Generic;
using EnumValuesLibrary;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SourceCode.Entities.StaticEatableObjects.Factory
{
    public class StaticEatableObjectsFactory : MonoBehaviour
    {
        [Inject] private readonly StaticEatableObjectsConfig _config;
        [Inject] private readonly DiContainer _container;
        
        private readonly Dictionary<StaticEatableObjectType, Transform> _parents = new();

        public event Action<StaticEatableObject> OnCreate;
        
        private void Awake()
        {
            var eatableObjectTypes = EnumValuesTool.GetValues<StaticEatableObjectType>();
            foreach (var eatableObjectType in eatableObjectTypes)
            {
                _parents.Add(eatableObjectType, new GameObject()
                {
                    name = eatableObjectType.ToString(),
                    transform = { parent = gameObject.transform }
                }.transform);
            }
        }

        public StaticEatableObject Create(StaticEatableObjectType staticEatableObjectType, Vector2 position)
        {
            var randomPrefabIndex = Random.Range(0, _config.EatableObjects[staticEatableObjectType].Count);
            var eatableGameObject = _container.InstantiatePrefab(_config.EatableObjects[staticEatableObjectType][randomPrefabIndex], position, quaternion.identity, _parents[staticEatableObjectType]);
            var eatableObject = eatableGameObject.GetComponent<StaticEatableObject>();
            
            OnCreate?.Invoke(eatableObject);
            return eatableObject;
        }
    }
}