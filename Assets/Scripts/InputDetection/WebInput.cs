using Joystick_Pack.Scripts.Joysticks;
using UnityEngine;

namespace SourceCode.InputDetection
{
    public class WebInput : IInputDetector
    {
        private readonly Joystick _joystick;
        
        public Vector2 MoveDirection { get; private set; }

        private WebInput(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void ManualUpdate()
        {
            var hor = Input.GetAxis("Horizontal") + _joystick.Horizontal;
            var vert = Input.GetAxis("Vertical") + _joystick.Vertical;

            MoveDirection = new Vector2(hor, vert);
        }
    }
}