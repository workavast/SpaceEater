using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.CameraMovement
{
    [CreateAssetMenu(fileName = nameof(CameraConfig), menuName = "Configs/" + nameof(CameraConfig))]
    public class CameraConfig : ScriptableObject, ISingleConfig
    {
        [field: SerializeField, Range(0, 20)] public float OrthographicSizeScale { get; private set; }
    }
}