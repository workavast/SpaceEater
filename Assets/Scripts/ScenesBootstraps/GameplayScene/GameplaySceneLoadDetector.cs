using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;
using UnityEngine.SceneManagement;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class GameplaySceneLoadDetector
    {
        private readonly SceneLoader _sceneLoader;

        public GameplaySceneLoadDetector(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            
            var gameplayMenuScreen = UI_ScreenRepository.GetScreen<GameplayMenuScreen>();
            gameplayMenuScreen.MainMenuButtonClicked += () => LoadScene(1);
        
            var gameplayEndScreen = UI_ScreenRepository.GetScreen<GameplayEndScreen>();
            gameplayEndScreen.RestartButtonClicked += () => LoadScene(2);
            gameplayEndScreen.MainMenuButtonClicked += () => LoadScene(1);
        }

        private void LoadScene(int sceneIndex)
            => _sceneLoader.LoadScene(sceneIndex);
    }
}