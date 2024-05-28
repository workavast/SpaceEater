using SourceCode.Core;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens;
using UnityEngine;
using Zenject;

namespace SourceCode.ScenesBootstraps.MainMenuScene
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private UI_Controller _uiController;
        private SceneLoadDetector _sceneLoadDetector;
        private UiScreenSwitcher _uiScreenSwitcher;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(UI_Controller uiController)
        {
            _uiController = uiController;
        }
        
        private void Start()
        {
            YandexPluginGameReadyApiInitializer.Initialize();
            FpsCap.Initialize();
            _uiController.Initialize();
            
            _sceneLoader = new SceneLoader();
            _sceneLoadDetector = new SceneLoadDetector(_sceneLoader);
            _uiScreenSwitcher = new UiScreenSwitcher(_uiController);
            
            _sceneLoader.Init();
        }
    }
}