using UnityEngine;

namespace SourceCode.Core.InputDetectors
{
    public abstract class InputDetectorBase
    {
        public Vector2 MoveDirection { get; protected set; }

        public abstract void ManualUpdate();
    }
}