using SourceCode.Localization;
using UnityEngine.UI;
using Zenject;

namespace SourceCode.Ui.Elements
{
    public class LocalizationButton : Button
    {
        private LocalizationManager _localizationManager;

        [Inject]
        public void Construct(LocalizationManager localizationManager)
        {
            _localizationManager = localizationManager;
        }
        
        public void _ChangeLocalization(int localizationIndex) 
            => _localizationManager.ChangeLocalization(localizationIndex);
    }
}
