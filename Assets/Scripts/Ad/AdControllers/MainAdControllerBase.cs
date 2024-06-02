using System;

namespace SourceCode.Ad.AdControllers
{
    public abstract class MainAdControllerBase : IAdTimer, IFullScreenAd
    {
        public abstract bool AdReady { get; }
        
        public abstract event Action FullScreenAdShowed;
        public abstract event Action FullScreenShowAdFailed;
        
        public abstract void ShowFullScreen();
    }
}