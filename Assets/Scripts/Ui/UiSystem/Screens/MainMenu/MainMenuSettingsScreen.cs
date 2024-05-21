using System;
using SourceCode.Ui.AnimationBlocks;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.MainMenu
{
    public class MainMenuSettingsScreen : UI_ScreenBase
    {
        [SerializeField] private Button backButton;
        [SerializeField] private AnimationMoveBlock animationMoveBlock;
        
        public event Action BackButtonClicked;

        private void Awake()
        {
            backButton.onClick.AddListener(() => BackButtonClicked?.Invoke());
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