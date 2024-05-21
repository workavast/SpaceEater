using System;
using Joystick_Pack.Scripts.Joysticks;
using SourceCode.Ui.AnimationBlocks;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.Gameplay
{
    public class GameplayMainScreen : UI_ScreenBase
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Button pauseButton;
        [SerializeField] private AnimationMoveBlock animationMoveBlock;
        [SerializeField] private AnimationRotateBlock animationRotateBlock;

        public event Action PauseButtonClicked;

        private void Awake()
        {
            pauseButton.onClick.AddListener(() => PauseButtonClicked?.Invoke());
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
                PauseButtonClicked?.Invoke();
        }

        protected override void Show()
        {
            gameObject.SetActive(true);
            joystick.gameObject.SetActive(true);
            animationMoveBlock.Show(null);
            animationRotateBlock.Show(null);
        }

        protected override void Hide()
        {
            joystick.gameObject.SetActive(false);
            animationMoveBlock.Hide(TryDeactivateScreen);
            animationRotateBlock.Hide(TryDeactivateScreen);
        }
        
        private void TryDeactivateScreen()
        {
            if(!animationMoveBlock.IsActive && !animationRotateBlock.IsActive)
                gameObject.SetActive(false);
        }
    }
}