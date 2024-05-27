using SourceCode.Core;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.MainMenu;

namespace SourceCode.ScenesBootstraps.MainMenuScene
{
    public class SceneLoadDetector
    {
        private readonly SceneLoader _sceneLoader;

        public SceneLoadDetector(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            
            var mainMenuScreen = UI_ScreenRepository.GetScreen<MainMenuScreen>();
            mainMenuScreen.PlayButtonClicked += () => LoadScene(2);
        }

        private void LoadScene(int sceneIndex)
            => _sceneLoader.LoadScene(sceneIndex);
    }
}