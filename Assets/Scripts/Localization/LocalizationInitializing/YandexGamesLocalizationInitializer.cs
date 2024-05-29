using YG;

namespace SourceCode.Localization.LocalizationInitializing
{
    public class YandexGamesLocalizationInitializer : ILocalizationInitializer
    {
        public int GetLocalization()
        {
            switch (YandexGame.lang)
            {
                case "ru":
                    return 1;
                case "tr":
                    return 2;
                default://en
                    return 0;
            }
        }
    }
}