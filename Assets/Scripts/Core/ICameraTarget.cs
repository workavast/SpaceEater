using System;
using UnityEngine;

namespace SourceCode.Core
{
    public interface ICameraTarget
    {
        public float Size { get; }
        public Transform Transform { get; }
        
        public event Action OnUpdateSize;
    }
}