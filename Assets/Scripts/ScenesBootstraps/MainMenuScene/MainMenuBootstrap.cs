using SourceCode.Core;
using SourceCode.Ui.UiSystem;
using UnityEngine;
using Zenject;

namespace SourceCode.ScenesBootstraps.MainMenuScene
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        [Inject] private UI_Controller _uiController;
        
        private GameSceneLoader _gameSceneLoader;
        private UiScreenSwitcher _uiScreenSwitcher;

        private void Start()
        {
            YandexPluginGameReadyApiInitializer.Initialize();
            FpsCap.Initialize();

            _uiController.Initialize();
            _gameSceneLoader = new GameSceneLoader();
            _uiScreenSwitcher = new UiScreenSwitcher(_uiController);
        }
    }
}