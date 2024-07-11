using System;
using SourceCode.Ad;
using SourceCode.Ad.Preparing;
using TMPro;
using UnityEngine;
using Zenject;

namespace SourceCode.Ui.UiSystem.Screens.Gameplay
{
    public class GameplayAdShowScreen : UI_ScreenBase
    {
        [SerializeField] private TMP_Text timer;
        
        [Inject] private readonly IAdPreparingTimer _adController;

        private int _currentTimerValue;

        private void Awake()
        {
            _adController.AdPreparedTimerUpdated += SetTimerValue;
        }

        private void SetTimerValue()
        {
            var time = _adController.CurrentPreparingTimerValue;
            if(_currentTimerValue == time)
                return;

            _currentTimerValue = time;
            timer.text = "" + time;
        }
        
        
        private void OnEnable() 
            => SetTimerValue();
    }
}