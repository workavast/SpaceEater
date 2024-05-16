using System;
using Joystick_Pack.Scripts.Joysticks;
using UnityEngine;
using UnityEngine.UI;

namespace SourceCode.Ui.UiSystem.Screens.Gameplay
{
    public class GameplayMainScreen : UI_ScreenBase
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Button pauseButton;

        public Joystick Joystick => joystick;
        
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
    }
}