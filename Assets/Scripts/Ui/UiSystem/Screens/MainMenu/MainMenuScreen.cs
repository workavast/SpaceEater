using System;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.MainMenu
{
    public class MainMenuScreen : UI_ScreenBase
    {
        [SerializeField] private Button playButton;
        
        public event Action PlayButtonClicked;

        private void Awake()
        {
            playButton.onClick.AddListener(() => PlayButtonClicked?.Invoke());
        }
    }
}
