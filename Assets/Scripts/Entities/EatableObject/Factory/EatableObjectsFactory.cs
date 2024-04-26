using System;
using System.Collections.Generic;
using EnumValuesLibrary;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SourceCode.Entities.EatableObject.Factory
{
    public class EatableObjectsFactory : MonoBehaviour
    {
        [Inject] private readonly EatableObjectsConfig _config;
        [Inject] private readonly DiContainer _container;
        
        private readonly Dictionary<EatableObjectType, Transform> _parents = new();

        public event Action<EatableObjectBehaviour> OnCreate;
        
        private void Awake()
        {
            var eatableObjectTypes = EnumValuesTool.GetValues<EatableObjectType>();
            foreach (var eatableObjectType in eatableObjectTypes)
            {
                _parents.Add(eatableObjectType, new GameObject()
                {
                    name = eatableObjectType.ToString(),
                    transform = { parent = gameObject.transform }
                }.transform);
            }
        }

        public EatableObjectBehaviour Create(EatableObjectType eatableObjectType, Vector2 position)
        {
            var randomPrefabIndex = Random.Range(0, _config.EatableObjects[eatableObjectType].Count);
            var eatableGameObject = _container.InstantiatePrefab(_config.EatableObjects[eatableObjectType][randomPrefabIndex], position, quaternion.identity, _parents[eatableObjectType]);
            var eatableObject = eatableGameObject.GetComponent<EatableObjectBehaviour>();
            
            OnCreate?.Invoke(eatableObject);
            return eatableObject;
        }
    }
}