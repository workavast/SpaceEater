using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Entities.BlackHole
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(BlackHoleConfig))]
    public class BlackHoleConfig : ScriptableObject, ISingleConfig
    {
        [field: SerializeField, Range(0, 10)] public float MoveSpeed { get; private set; }
        [field: SerializeField, Range(0, 10)] public float IncreaseScale { get; private set; }
    }
}