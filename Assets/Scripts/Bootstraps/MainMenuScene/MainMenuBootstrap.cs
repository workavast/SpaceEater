using SourceCode.Core;
using SourceCode.Ui.UiSystem;
using UnityEngine;
using Zenject;

namespace SourceCode.Bootstraps.MainMenuScene
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        [Inject] private UI_Controller _uiController;
        
        private GameSceneLoader _gameSceneLoader;
        
        private void Start()
        {
            YandexPluginGameReadyApiInitializer.Initialize();
            FpsCap.Initialize();

            _uiController.Initialize();
            _gameSceneLoader = new GameSceneLoader();
        }
    }
}