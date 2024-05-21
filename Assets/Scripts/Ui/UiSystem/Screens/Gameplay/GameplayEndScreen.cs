using System;
using SourceCode.Ui.AnimationBlocks;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.Gameplay
{
    public class GameplayEndScreen : UI_ScreenBase
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private SuccessMark successMark;
        [SerializeField] private AnimationFadeBlock animationFadeBlock;
        [SerializeField] private AnimationMoveBlock animationMoveBlockUp;
        [SerializeField] private AnimationMoveBlock animationMoveBlockDown;

        public event Action RestartButtonClicked;
        public event Action MainMenuButtonClicked;

        public void SetGameSuccess(bool isSuccess)
            => successMark.SetGameSuccess(isSuccess);

        private void Awake()
        {
            restartButton.onClick.AddListener(() => RestartButtonClicked?.Invoke());
            mainMenuButton.onClick.AddListener(() => MainMenuButtonClicked?.Invoke());
        }

        protected override void Show()
        {
            gameObject.SetActive(true);
            animationFadeBlock.Show(null);
            animationMoveBlockUp.Show(null);
            animationMoveBlockDown.Show(null);
        }

        protected override void Hide()
        {
            animationFadeBlock.Hide(null);
            animationMoveBlockUp.Hide(null);
            animationMoveBlockDown.Hide(null);
        }

        private void TryDeactivateScreen()
        {
            if(!animationFadeBlock.IsActive && !animationMoveBlockUp.IsActive && !animationMoveBlockDown.IsActive)
                gameObject.SetActive(false);
        }
        
        [Serializable]
        private class SuccessMark
        {
            [SerializeField] private GameObject successMark;
            [SerializeField] private GameObject unSuccessMark;

            public void SetGameSuccess(bool isSuccess)
            {
                successMark.SetActive(isSuccess);
                unSuccessMark.SetActive(!isSuccess);
            }
        }
    }
}