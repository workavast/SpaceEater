using System.Collections.Generic;
using SourceCode.ConfigsCore;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects.Factory
{
    [CreateAssetMenu(fileName = nameof(StaticEatableObjectsConfig), menuName = "Configs/" + nameof(StaticEatableObjectsConfig))]
    public class StaticEatableObjectsConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField] private List<StaticEatableObject> eatableObjects;
        
        public IReadOnlyList<StaticEatableObject> EatableObjectsList => eatableObjects;
        
        // Doesnt work in webGl, in build you will take empty dictionary
        // private readonly Dictionary<StaticEatableObjectType, List<StaticEatableObject>> _eatableObjects = new();
        // public IReadOnlyDictionary<StaticEatableObjectType, List<StaticEatableObject>> EatableObjects => _eatableObjects;
        //
        // private void OnValidate()
        // {
        //     _eatableObjects.Clear();
        //     foreach (var eatableObject in eatableObjects)
        //     {
        //         if (_eatableObjects.ContainsKey(eatableObject.StaticEatableObjectType))
        //             _eatableObjects[eatableObject.StaticEatableObjectType].Add(eatableObject);
        //         else
        //             _eatableObjects.Add(eatableObject.StaticEatableObjectType, new List<StaticEatableObject>(){eatableObject});
        //     }
        // }
    }
}