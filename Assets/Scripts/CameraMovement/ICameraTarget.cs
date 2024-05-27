using System;
using UnityEngine;

namespace SourceCode.CameraMovement
{
    public interface ICameraTarget
    {
        public float TargetSize { get; }
        public Transform Transform { get; }
        
        public event Action OnUpdateTargetSize;
    }
}