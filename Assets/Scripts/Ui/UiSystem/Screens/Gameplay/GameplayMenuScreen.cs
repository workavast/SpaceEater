using System;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.Gameplay
{
    public class GameplayMenuScreen : UI_ScreenBase
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button mainMenuButton;
        
        public event Action ContinueButtonClicked;
        public event Action MainMenuButtonClicked;
        
        private void Awake()
        {
            continueButton.onClick.AddListener(() => ContinueButtonClicked?.Invoke());
            mainMenuButton.onClick.AddListener(() => MainMenuButtonClicked?.Invoke());
        }
    }
}