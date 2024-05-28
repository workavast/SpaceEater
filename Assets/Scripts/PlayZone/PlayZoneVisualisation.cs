using UnityEngine;
using Zenject;

namespace SourceCode.PlayZone
{
    public class PlayZoneVisualisation : MonoBehaviour
    {
        private PlayZoneConfig _config;

        [Inject]
        public void Construct(PlayZoneConfig config)
        {
            _config = config;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(Vector2.zero, _config.Radius);
        }
    }
}