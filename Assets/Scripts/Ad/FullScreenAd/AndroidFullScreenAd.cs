using System;

namespace SourceCode.Ad.FullScreenAd
{
    public class AndroidFullScreenAd : IFullScreenAd
    {
        public event Action Showed;
        public event Action OnError;
        
        public void Show()
        {
            
        }
    }
}