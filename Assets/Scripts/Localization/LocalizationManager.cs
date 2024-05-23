using System.Threading.Tasks;
using SourceCode.Core.GlobalData;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace SourceCode.Localization
{
    public class LocalizationManager
    {
        private bool _active;
        
        public async void ChangeLocalization(int localizationId)
        {
            if(_active || PlayerGlobalData.Instance.LocalizationSettings.LocalizationId == localizationId)
                return;
            
            if (localizationId >= LocalizationSettings.AvailableLocales.Locales.Count || localizationId < 0)
            {
                Debug.LogError("Invalid localization Id");
                return;
            }
            
            await ApplyLocalization(localizationId);
            
            PlayerGlobalData.Instance.LocalizationSettings.ChangeLocalization(localizationId);
        }

        private async Task ApplyLocalization(int localizationId)
        {
            _active = true;

            var handleTask = LocalizationSettings.InitializationOperation;
            await handleTask.Task;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localizationId];
            
            _active = false;
        }
    }
}