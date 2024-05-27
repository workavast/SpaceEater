using System;
using UnityEngine;

namespace SourceCode.TriggerZone
{
    public class TriggerZone2D : MonoBehaviour
    {
        public event Action<Collider2D> OnEnter;
        public event Action<Collider2D> OnExit;
        
        private void OnTriggerEnter2D(Collider2D other)
            => OnEnter?.Invoke(other);

        private void OnTriggerExit2D(Collider2D other)
            => OnExit?.Invoke(other);
    }
}