using System;

namespace SourceCode.Ad.FullScreenAd
{
    public interface IFullScreenAd
    {
        public event Action Showed;
        public event Action OnError;
        
        public void Show();
    }
}