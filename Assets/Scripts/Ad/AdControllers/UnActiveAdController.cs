using System;

namespace SourceCode.Ad.AdControllers
{
    public class UnActiveAdController : MainAdControllerBase
    {
        public override bool AdReady => false;
        
        public override event Action FullScreenAdShowed;
        public override event Action FullScreenShowAdFailed;
        
        public override void ShowFullScreen()
        {
            FullScreenAdShowed?.Invoke();
        }
    }
}