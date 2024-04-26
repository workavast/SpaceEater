using System.Collections.Generic;
using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Entities.EatableObject.Factory
{
    [CreateAssetMenu(fileName = nameof(EatableObjectsConfig), menuName = "Configs/" + nameof(EatableObjectsConfig))]
    public class EatableObjectsConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField] private List<EatableObjectBehaviour> eatableObjects;

        private readonly Dictionary<EatableObjectType, List<EatableObjectBehaviour>> _eatableObjects = new();
        public IReadOnlyDictionary<EatableObjectType, List<EatableObjectBehaviour>> EatableObjects => _eatableObjects;
        
        private void OnValidate()
        {
            _eatableObjects.Clear();
            foreach (var eatableObject in eatableObjects)
            {
                if (_eatableObjects.ContainsKey(eatableObject.EatableObjectType))
                    _eatableObjects[eatableObject.EatableObjectType].Add(eatableObject);
                else
                    _eatableObjects.Add(eatableObject.EatableObjectType, new List<EatableObjectBehaviour>(){eatableObject});
            }
        }
    }
}