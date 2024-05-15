using System;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.MainMenu
{
    public class MainMenuSettingsScreen : UI_ScreenBase
    {
        [SerializeField] private Button backButton;
        
        public event Action BackButtonClicked;

        private void Awake()
        {
            backButton.onClick.AddListener(() => BackButtonClicked?.Invoke());
        }
    }
}