using UnityEngine;

namespace SourceCode.Localization.LocalizationInitializing
{
    public class AndroidLocalizationInitializer : ILocalizationInitializer
    {
        public int GetLocalization()
        {
            switch (Application.systemLanguage)
            {
                case SystemLanguage.Russian:
                    return 1;
                case SystemLanguage.Turkish:
                    return 2;
                case SystemLanguage.Ukrainian:
                    return 1;
                default://English
                    return 0;
            }
        }
    }
}