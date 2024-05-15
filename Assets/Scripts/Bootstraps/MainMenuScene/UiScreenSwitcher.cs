using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.MainMenu;

namespace SourceCode.Bootstraps.MainMenuScene
{
    public class UiScreenSwitcher
    {
        public UiScreenSwitcher(UI_Controller uiController)
        {
            var mainMenuScreen = UI_ScreenRepository.GetScreen<MainMenuScreen>();
            mainMenuScreen.SettingsButtonClicked += uiController.SetScreen<MainMenuSettingsScreen>;
            
            var mainMenuSettingsScreen = UI_ScreenRepository.GetScreen<MainMenuSettingsScreen>();
            mainMenuSettingsScreen.BackButtonClicked += uiController.SetScreen<MainMenuScreen>;
        }
    }
}