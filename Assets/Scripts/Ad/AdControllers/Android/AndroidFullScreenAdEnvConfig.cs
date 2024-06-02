using SourceCode.ConfigsCore;
using UnityEngine;

namespace SourceCode.Ad.AdControllers.Android
{
    [CreateAssetMenu(fileName = nameof(AndroidFullScreenAdEnvConfig), menuName = "Configs/" + nameof(AndroidFullScreenAdEnvConfig))]
    public class AndroidFullScreenAdEnvConfig : ScriptableObject, ISingleConfig
    {
        [field: SerializeField, Min(0)] public float TimerBeforeAdShow { get; private set; } = 50;
        [field: SerializeField, Min(0)] public float AdLoadTimer { get; private set; } = 3;
    }
}