using UnityEngine.EventSystems;

namespace Joystick_Pack.Scripts.Joysticks
{
    public class FloatingJoystick : Joystick
    {
        protected override void Start()
        {
            base.Start();
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void Reset()
        {
            background.gameObject.SetActive(false);
            base.Reset();
        }
    }
}