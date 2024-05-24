using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects.StaticEatableObjectsBySizeRemoving
{
    [CreateAssetMenu(fileName = nameof(StaticEatableObjectsBySizeRemoverConfig), menuName = "Configs/" + nameof(StaticEatableObjectsBySizeRemoverConfig))]
    public class StaticEatableObjectsBySizeRemoverConfig : ScriptableObject
    {
        [field: SerializeField] public float ScaleDifference { get; private set; } = 17.5f;
    }
}