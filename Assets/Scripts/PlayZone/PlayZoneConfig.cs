using SourceCode.ConfigsCore;
using UnityEngine;

namespace SourceCode.PlayZone
{
    [CreateAssetMenu(fileName = nameof(PlayZoneConfig), menuName = "Configs/" + nameof(PlayZoneConfig))]
    public class PlayZoneConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField] private float radius;
        
        public float Radius => radius;
    }
}