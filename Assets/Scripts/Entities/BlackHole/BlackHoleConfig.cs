using DG.Tweening;
using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Entities.BlackHole
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(BlackHoleConfig))]
    public class BlackHoleConfig : EatableObjectConfigBase, ISingleConfig
    {
        [field: SerializeField, Range(0, 10)] public float MoveSpeed { get; private set; }
        [field: SerializeField, Range(0, 10)] public float IncreaseScale { get; private set; }
        [field: SerializeField, Range(0, 180)] public float ModelRotation { get; private set; } = 30;

        [field: Header("Change scale animation:")]
        [field: SerializeField, Min(0)] public float ChangeScaleDuration { get; private set; } = 1;
        [field: SerializeField] public Ease ChangeScaleEaseType { get; private set; } = Ease.Linear;
    }
}