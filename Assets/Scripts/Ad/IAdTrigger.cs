using System;

namespace SourceCode.Ad
{
    public interface IAdTrigger
    {
        public event Action AdActivationTriggered;
    }
}