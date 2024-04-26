using UnityEngine;

namespace SourceCode.Core
{
    public static class FpsCap
    {
        public static void Initialize()
        {
            Application.targetFrameRate = 60;
        }
    }
}