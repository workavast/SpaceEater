using System;

namespace SourceCode.Ad.Preparing
{
    public interface IAdPreparedTrigger
    {
        public event Action AdPreparingTriggered;
    }
}