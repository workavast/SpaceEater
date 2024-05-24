using System;

namespace SourceCode.Core.Ad
{
    public interface IAdTrigger
    {
        public event Action AdActivationTriggered;
    }
}