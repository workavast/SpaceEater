using UnityEngine;

namespace SourceCode.InputDetection
{
    public interface IInputDetector
    {
        public Vector2 MoveDirection { get; }

        public void ManualUpdate();
    }
}