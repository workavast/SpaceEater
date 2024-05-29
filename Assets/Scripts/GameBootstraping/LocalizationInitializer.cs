using SourceCode.Core.GlobalData;
using SourceCode.Localization;
using SourceCode.Localization.LocalizationInitializing;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Initializers
{
    public class LocalizationInitializer : InitializerBase
    {
#if PLATFORM_WEBGL
        private readonly ILocalizationInitializer _localizationInitializer = new YandexGamesLocalizationInitializer();
#elif PLATFORM_ANDROID
        private readonly ILocalizationInitializer _localizationInitializer = new AndroidLocalizationInitializer();
#endif
        
        public LocalizationInitializer(InitializerBase[] initializers = null) 
            : base(initializers) { }

        public override void Init() => InitLocalizationSettings();

        private async void InitLocalizationSettings()
        {
            var handleTask = LocalizationSettings.InitializationOperation;
            await handleTask.Task;

            int langIndex = 1;
            if (PlayerGlobalData.Instance.IsFirstSession)
                langIndex = _localizationInitializer.GetLocalization();
            else
                langIndex = PlayerGlobalData.Instance.LocalizationSettings.LocalizationId;
            
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[langIndex];
            
            var handleTask2 = LocalizationSettings.InitializationOperation;
            await handleTask2.Task;
            PlayerGlobalData.Instance.LocalizationSettings.ChangeLocalization(langIndex);

            Debug.Log("-||- LocalizationInitializer");
            OnParentInit?.Invoke();
        }
    }
}
