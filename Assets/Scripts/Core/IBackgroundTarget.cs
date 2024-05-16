using System;
using UnityEngine;

namespace SourceCode.Core
{
    public interface IBackgroundTarget
    {
        public Transform Transform { get; }
        public float Size { get; }

        public event Action OnUpdateSize;
        public event Action<Vector2, float> OnMove;
    }
}