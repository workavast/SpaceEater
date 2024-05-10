using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;
using SourceCode.Ui.UiSystem.Screens.MainMenu;
using UnityEngine.SceneManagement;

namespace SourceCode.Bootstraps.MainMenuScene
{
    public class GameSceneLoader
    {
        public GameSceneLoader()
        {
            var mainMenuScreen = UI_ScreenRepository.GetScreen<MainMenuScreen>();
            mainMenuScreen.PlayButtonClicked += () => LoadScene(2);
        }

        private static void LoadScene(int sceneIndex)
            => SceneManager.LoadScene(sceneIndex);
    }
}