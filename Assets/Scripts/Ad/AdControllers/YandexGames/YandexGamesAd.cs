using System;
using YG;

namespace SourceCode.Ad.AdControllers.YandexGames
{
    public sealed class YandexGamesAd : MainAdControllerBase
    {
        public override bool AdReady => YandexGame.timerShowAd >= YandexGame.Instance.infoYG.fullscreenAdInterval;
        
        public override event Action FullScreenAdShowed;
        public override event Action FullScreenShowAdFailed;

        public YandexGamesAd()
        {
            YandexGame.CloseFullAdEvent += () => FullScreenAdShowed?.Invoke();
            YandexGame.ErrorFullAdEvent += () => FullScreenShowAdFailed?.Invoke();
        }
        
        public override void ShowFullScreen() 
            => YandexGame.FullscreenShow();
    }
}