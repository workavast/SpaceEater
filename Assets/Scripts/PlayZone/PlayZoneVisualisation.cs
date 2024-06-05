using UnityEngine;
using Zenject;

namespace SourceCode.PlayZone
{
    public class PlayZoneVisualisation : MonoBehaviour
    {
        [SerializeField] private PlayZoneConfig config;

        [Inject]
        public void Construct(PlayZoneConfig config)
        {
            this.config = config;
        }
        
        private void OnDrawGizmos()
        {
            if(config == null)
                return;
            
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(Vector2.zero, config.Radius);
        }
    }
}