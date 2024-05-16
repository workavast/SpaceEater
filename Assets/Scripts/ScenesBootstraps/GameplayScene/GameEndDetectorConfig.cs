using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    [CreateAssetMenu(fileName = nameof(GameEndDetectorConfig), menuName = "Configs/" + nameof(GameEndDetectorConfig))]
    public class GameEndDetectorConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField, Range(0, 1)] private float staticObjectsConsumedPercentageForEnd;

        public float StaticObjectsConsumedPercentageForEnd => staticObjectsConsumedPercentageForEnd;
    }
}