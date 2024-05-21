using System;
using SourceCode.Ui.AnimationBlocks;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.Gameplay
{
    public class GameplayMenuScreen : UI_ScreenBase
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private AnimationMoveBlock animationMoveBlockLeft;
        [SerializeField] private AnimationMoveBlock animationMoveBlockRight;
        
        public event Action ContinueButtonClicked;
        public event Action MainMenuButtonClicked;
        
        private void Awake()
        {
            continueButton.onClick.AddListener(() => ContinueButtonClicked?.Invoke());
            mainMenuButton.onClick.AddListener(() => MainMenuButtonClicked?.Invoke());
        }

        protected override void Show()
        {
            gameObject.SetActive(true);
            animationMoveBlockLeft.Show(null);
            animationMoveBlockRight.Show(null);
        }

        protected override void Hide()
        {
            animationMoveBlockLeft.Hide(TryDeactivateScreen);
            animationMoveBlockRight.Hide(TryDeactivateScreen);
        }

        private void TryDeactivateScreen()
        {
            if(!animationMoveBlockLeft.IsActive && !animationMoveBlockRight.IsActive)
                gameObject.SetActive(false);
        }
    }
}