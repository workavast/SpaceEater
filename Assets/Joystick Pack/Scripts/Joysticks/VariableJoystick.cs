using UnityEngine;
using UnityEngine.EventSystems;

namespace Joystick_Pack.Scripts.Joysticks
{
    public class VariableJoystick : Joystick
    {
        [SerializeField] private float moveThreshold = 1;
        [SerializeField] private JoystickType joystickType = JoystickType.Fixed;
        
        public float MoveThreshold { get => moveThreshold; set => moveThreshold = Mathf.Abs(value); }

        private Vector2 _fixedPosition = Vector2.zero;

        public void SetMode(JoystickType newJoystickType)
        {
            this.joystickType = newJoystickType;
            if(newJoystickType == JoystickType.Fixed)
            {
                background.anchoredPosition = _fixedPosition;
                background.gameObject.SetActive(true);
            }
            else
                background.gameObject.SetActive(false);
        }

        protected override void Start()
        {
            base.Start();
            _fixedPosition = background.anchoredPosition;
            SetMode(joystickType);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if(joystickType != JoystickType.Fixed)
            {
                background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
                background.gameObject.SetActive(true);
            }
            base.OnPointerDown(eventData);
        }

        public override void Reset()
        {
            if(joystickType != JoystickType.Fixed)
                background.gameObject.SetActive(false);

            base.Reset();
        }

        protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (joystickType == JoystickType.Dynamic && magnitude > moveThreshold)
            {
                Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
                background.anchoredPosition += difference;
            }
            base.HandleInput(magnitude, normalised, radius, cam);
        }
    }

    public enum JoystickType { Fixed, Floating, Dynamic }
}