using UnityEngine;

namespace SourceCode.Core.PlayZone
{
    public class PlayZoneVisualisation : MonoBehaviour
    {
        [SerializeField] private PlayZoneConfig config;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(Vector2.zero, config.Radius);
        }
    }
}