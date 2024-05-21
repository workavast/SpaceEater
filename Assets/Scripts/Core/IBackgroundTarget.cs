using System;
using UnityEngine;

namespace SourceCode.Core
{
    public interface IBackgroundTarget
    {
        public Transform Transform { get; }
        public float TargetSize { get; }

        public event Action OnUpdateTargetSize;
        public event Action<Vector2, float> OnMove;
    }
}