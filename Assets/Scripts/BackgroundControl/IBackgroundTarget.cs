using System;
using UnityEngine;

namespace SourceCode.BackgroundControl
{
    public interface IBackgroundTarget
    {
        public Transform Transform { get; }
        public float Size { get; }

        public event Action OnUpdateSize;
        public event Action<Vector2, float> OnMove;
    }
}