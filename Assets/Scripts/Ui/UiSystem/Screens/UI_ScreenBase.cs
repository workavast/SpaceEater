using UnityEngine;

namespace SourceCode.Ui.UiSystem.Screens
{
    public abstract class UI_ScreenBase : MonoBehaviour
    {
        public void SetActive(bool isActive)
        {
            if (isActive)
                Show();
            else
                Hide();
        }
        
        protected virtual void Show() 
            => gameObject.SetActive(true);

        protected virtual void Hide() 
            => gameObject.SetActive(false);
    }
}