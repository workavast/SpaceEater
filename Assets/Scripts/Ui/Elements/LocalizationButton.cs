using SourceCode.Localization;
using UnityEngine.UI;
using Zenject;

namespace SourceCode.Ui.Elements
{
    public class LocalizationButton : Button
    {
        private ILocalizationManager _localizationManager;

        [Inject]
        public void Construct(ILocalizationManager localizationManager)
        {
            _localizationManager = localizationManager;
        }
        
        public void _ChangeLocalization(int localizationIndex) 
            => _localizationManager.ChangeLocalization(localizationIndex);
    }
}
