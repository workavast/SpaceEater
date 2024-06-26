using DG.Tweening;
using SourceCode.ConfigsCore;
using UnityEngine;

namespace SourceCode.BackgroundControl
{
    [CreateAssetMenu(fileName = nameof(BackgroundConfig), menuName = "Configs/" + nameof(BackgroundConfig))]
    public class BackgroundConfig : ScriptableObject, ISingleConfig
    {
        [field: SerializeField, Range(0, 10)] public float MoveSpeed { get; private set; }
        [field: SerializeField, Range(0, 1)] public float SizeScaler { get; private set; }
        
        [field: SerializeField, Range(0, 2)] public float BackgroundMoveScale { get; private set; }
        [field: SerializeField, Range(0, 2)] public float StarsMoveScale { get; private set; }

        [field: Header("Change scale animation:")]
        [field: SerializeField, Min(0)] public float ChangeScaleDuration { get; private set; } = 1;
        [field: SerializeField] public Ease ChangeScaleEaseType { get; private set; }
    }
}