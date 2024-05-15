using SourceCode.Ui.UiSystem.Screens;
using UnityEngine;

namespace SourceCode.Ui.UiSystem
{
    public class UI_Controller : MonoBehaviour
    {
        private UI_ScreenBase _uiActive;
        
        public void Initialize()
        {
            foreach (var screen in UI_ScreenRepository.Screens)
                if (screen.isActiveAndEnabled)
                {
                    _uiActive = screen;
                    break;
                }

            if (_uiActive == null)
                Debug.LogWarning("No have active screen");
        }

        public void SetScreen<TScreen>()
            where TScreen : UI_ScreenBase
        {
            var newScreen = UI_ScreenRepository.GetScreen<TScreen>();
            
            _uiActive.SetActive(false);
            _uiActive = newScreen;
            _uiActive.SetActive(true);
        }    
    }
}