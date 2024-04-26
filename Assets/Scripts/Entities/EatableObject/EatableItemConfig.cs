using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Entities.EatableObject
{
    [CreateAssetMenu(fileName = nameof(EatableItemConfig), menuName = "Config/" + nameof(EatableItemConfig))]
    public class EatableItemConfig : ScriptableObject, ISingleConfig
    {
        [field: SerializeField, Range(0, 10)] public float EatTime { get; private set; }
    }
}