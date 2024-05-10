using YG;

namespace SourceCode.Core
{
    public static class YandexPluginGameReadyApiInitializer
    {
        private static bool _initialized;
        
        public static void Initialize()
        {
            if (_initialized) 
                return;
            
            YandexGame.GameReadyAPI();
            _initialized = true;
        }
    }
}
