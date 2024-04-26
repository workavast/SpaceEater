using System;
using UnityEngine;

namespace SourceCode.Entities
{
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class EntityBase : MonoBehaviour
    {
        private float _colliderRadius;

        public float Size => transform.localScale.x * _colliderRadius;

        protected virtual void Awake()
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (Math.Abs(transform.localScale.x - transform.localScale.y) > 0.01f)
                Debug.LogWarning($"Attention! Scales of object ({gameObject.name}) dont equal: {transform.localScale}");
#endif
            
            _colliderRadius = GetComponent<CircleCollider2D>().radius;
        }
    }
}