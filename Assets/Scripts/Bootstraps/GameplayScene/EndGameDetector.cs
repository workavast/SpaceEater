using System;
using SourceCode.Entities;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.Bootstraps.GameplayScene
{
    public class EndGameDetector
    {
        public event Action GameEnded;
        
        public EndGameDetector(EntityBase entity)
        {
            var screen = UI_ScreenRepository.GetScreen<GameplayMainScreen>();
            
            entity.OnConsumed += () => GameEnded?.Invoke();
            screen.PauseButtonClicked += () => GameEnded?.Invoke();
        }
    }
}