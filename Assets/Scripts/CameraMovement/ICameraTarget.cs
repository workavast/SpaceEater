using System;
using UnityEngine;

namespace CameraMovement
{
    public interface ICameraTarget
    {
        public float TargetSize { get; }
        public Transform Transform { get; }
        
        public event Action OnUpdateTargetSize;
    }
}