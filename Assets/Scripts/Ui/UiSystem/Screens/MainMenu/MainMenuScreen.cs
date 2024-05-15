using System;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.MainMenu
{
    public class MainMenuScreen : UI_ScreenBase
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        
        public event Action PlayButtonClicked;
        public event Action SettingsButtonClicked;

        private void Awake()
        {
            playButton.onClick.AddListener(() => PlayButtonClicked?.Invoke());
            settingsButton.onClick.AddListener(() => SettingsButtonClicked?.Invoke());
        }
    }
}
