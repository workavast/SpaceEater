using UnityEngine;

namespace SourceCode.Core
{
    public static class FpsCap
    {
        private static bool _initialized;
        
        public static void Initialize()
        {
            if (_initialized) 
                return;
            
            Application.targetFrameRate = 60;
            _initialized = true;
        }
    }
}