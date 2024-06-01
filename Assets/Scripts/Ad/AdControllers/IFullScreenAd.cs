using System;

namespace SourceCode.Ad.AdControllers
{
    public interface IFullScreenAd
    {
        public event Action FullScreenAdShowed;
        public event Action FullScreenShowAdFailed;
        
        public void ShowFullScreen();
    }
}