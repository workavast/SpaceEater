using UnityEngine;

namespace SourceCode.InputDetectors
{
    public class DesktopInput : InputDetectorBase
    {
        public override void ManualUpdate()
        {
            var hor = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");

            MoveDirection = new Vector2(hor, vert);
        }
    }
}