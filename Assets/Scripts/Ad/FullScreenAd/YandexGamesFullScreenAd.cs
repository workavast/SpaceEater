using System;
using YG;

namespace SourceCode.Ad.FullScreenAd
{
    public class YandexGamesFullScreenAd : IFullScreenAd
    {
        public event Action Showed;
        public event Action OnError;

        public YandexGamesFullScreenAd()
        {
            YandexGame.CloseFullAdEvent += () => Showed?.Invoke();
            YandexGame.ErrorFullAdEvent += () => OnError?.Invoke();
        }
        
        public void Show() 
            => YandexGame.FullscreenShow();
    }
}