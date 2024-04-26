using UnityEngine;

namespace SourceCode.Core.PlayZone
{
    public class PlayZoneBehaviour : MonoBehaviour
    {
        [field: SerializeField] public float Radius { get; private set; }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(Vector2.zero, Radius);
        }
    }
}