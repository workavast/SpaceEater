using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Core.Ad
{
    [CreateAssetMenu(fileName = nameof(AdPreparingConfig), menuName = "Configs/" + nameof(AdPreparingConfig))]
    public class AdPreparingConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField, Range(0, 10)] private float adPreparingTime = 3;

        public float AdPreparingTime => adPreparingTime;
    }
}