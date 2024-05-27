using DG.Tweening;
using SourceCode.ConfigsCore;
using UnityEngine;

namespace SourceCode.CameraMovement
{
    [CreateAssetMenu(fileName = nameof(CameraConfig), menuName = "Configs/" + nameof(CameraConfig))]
    public class CameraConfig : ScriptableObject, ISingleConfig
    {
        [field: SerializeField, Range(0, 20)] public float OrthographicSizeScale { get; private set; }
        
        [field: Header("Change scale animation:")]
        [field: SerializeField, Min(0)] public float ChangeScaleDuration { get; private set; } = 1;
        [field: SerializeField] public Ease ChangeScaleEaseType { get; private set; } = Ease.Linear;
    }
}