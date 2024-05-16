using UnityEngine;

namespace SourceCode.Core.InputDetectors
{
    public interface IInputDetector
    {
        public Vector2 MoveDirection { get; }

        public void ManualUpdate();
    }
}