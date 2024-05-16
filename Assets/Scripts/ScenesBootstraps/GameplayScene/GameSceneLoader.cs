using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;
using UnityEngine.SceneManagement;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class GameSceneLoader
    {
        public GameSceneLoader()
        {
            var gameplayMenuScreen = UI_ScreenRepository.GetScreen<GameplayMenuScreen>();
            gameplayMenuScreen.MainMenuButtonClicked += () => LoadScene(1);
        
            var gameplayEndScreen = UI_ScreenRepository.GetScreen<GameplayEndScreen>();
            gameplayEndScreen.RestartButtonClicked += () => LoadScene(2);
            gameplayEndScreen.MainMenuButtonClicked += () => LoadScene(1);
        }

        private static void LoadScene(int sceneIndex)
            => SceneManager.LoadScene(sceneIndex);
    }
}