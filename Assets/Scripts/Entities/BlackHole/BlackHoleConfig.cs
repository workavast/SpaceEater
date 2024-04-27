using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Entities.BlackHole
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(BlackHoleConfig))]
    public class BlackHoleConfig : EatableObjectConfigBase, ISingleConfig
    {
        [field: SerializeField, Range(0, 10)] public float MoveSpeed { get; private set; }
        [field: SerializeField, Range(0, 10)] public float IncreaseScale { get; private set; }
        [SerializeField, Range(0, 180)] private float modelRotation;

        public float ModelRotation => modelRotation;
    }
}