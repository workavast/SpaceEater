using System;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.Gameplay
{
    public class GameplayEndScreen : UI_ScreenBase
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private GameObject darkBackground;
        [SerializeField] private SuccessMark successMark;

        public event Action RestartButtonClicked;
        public event Action MainMenuButtonClicked;

        public void SetGameSuccess(bool isSuccess)
            => successMark.SetGameSuccess(isSuccess);

        private void Awake()
        {
            restartButton.onClick.AddListener(() => RestartButtonClicked?.Invoke());
            mainMenuButton.onClick.AddListener(() => MainMenuButtonClicked?.Invoke());
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