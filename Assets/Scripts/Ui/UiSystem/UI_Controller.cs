using System.Collections.Generic;
using SourceCode.Ui.UiSystem.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void SetScreen(ScreenType screen)
        {
            var newScreen = UI_ScreenRepository.GetScreen(screen);
            
            _uiActive.SetActive(false);
            _uiActive = newScreen;
            _uiActive.SetActive(true);
        }    
    
        public void LoadScene(int sceneBuildIndex)
        {
            if (sceneBuildIndex == -1)
            {
                int currentSceneNum = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneNum, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene(sceneBuildIndex);
            }
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}