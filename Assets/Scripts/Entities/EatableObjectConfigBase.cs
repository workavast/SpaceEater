using UnityEngine;

namespace SourceCode.Entities
{
    public abstract class EatableObjectConfigBase : ScriptableObject
    {
        [field: SerializeField, Range(0, 10)] public float EatTime { get; private set; }
    }
}