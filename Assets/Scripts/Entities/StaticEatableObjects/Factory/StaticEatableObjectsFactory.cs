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
        private DiContainer _container;
        
        private readonly Dictionary<StaticEatableObjectType, Transform> _parents = new();
        private readonly Dictionary<StaticEatableObjectType, List<StaticEatableObject>> _eatableObjects = new();

        public event Action<StaticEatableObject> OnCreate;

        [Inject]
        public void Construct(StaticEatableObjectsConfig config, DiContainer diContainer)
        {
            InitEatableObjects(config.EatableObjectsList);
            _container = diContainer;
        }
        
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

        public StaticEatableObject Create(StaticEatableObjectType staticEatableObjectType, Vector2 position, float scale, float rotation)
        {
            var randomPrefabIndex = Random.Range(0, _eatableObjects[staticEatableObjectType].Count);
            var eatableGameObject = _container.InstantiatePrefab(
                _eatableObjects[staticEatableObjectType][randomPrefabIndex], position, 
                quaternion.identity, _parents[staticEatableObjectType]);
            var eatableObject = eatableGameObject.GetComponent<StaticEatableObject>();
            eatableObject.transform.localScale = new Vector3(scale, scale, 1);
            eatableObject.SetModelRotation(rotation);
            
            OnCreate?.Invoke(eatableObject);
            return eatableObject;
        }
        
        private void InitEatableObjects(IEnumerable<StaticEatableObject> eatableObjects)
        {
            _eatableObjects.Clear();
            foreach (var eatableObject in eatableObjects)
            {
                if (_eatableObjects.ContainsKey(eatableObject.StaticEatableObjectType))
                    _eatableObjects[eatableObject.StaticEatableObjectType].Add(eatableObject);
                else
                    _eatableObjects.Add(eatableObject.StaticEatableObjectType, new List<StaticEatableObject>(){eatableObject});
            }
        }
    }
}