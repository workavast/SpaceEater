using System;
using SourceCode.Ui.AnimationBlocks;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.MainMenu
{
    public class MainMenuScreen : UI_ScreenBase
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private AnimationMoveBlock animationMoveBlock;
        
        public event Action PlayButtonClicked;
        public event Action SettingsButtonClicked;

        private void Awake()
        {
            playButton.onClick.AddListener(() => PlayButtonClicked?.Invoke());
            settingsButton.onClick.AddListener(() => SettingsButtonClicked?.Invoke());
        }
        
        protected override void Show()
        {
            gameObject.SetActive(true);
            animationMoveBlock.Show(null);
        }

        protected override void Hide()
        {
            animationMoveBlock.Hide(() => gameObject.SetActive(false));
        }
    }
}
