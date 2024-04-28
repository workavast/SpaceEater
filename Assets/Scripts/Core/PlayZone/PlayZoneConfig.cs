using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Core.PlayZone
{
    [CreateAssetMenu(fileName = nameof(PlayZoneConfig), menuName = "Configs/" + nameof(PlayZoneConfig))]
    public class PlayZoneConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField] private float radius;
        
        public float Radius => radius;
    }
}