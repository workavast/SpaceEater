using System;

namespace SourceCode.ScenesBootstraps.GameplayScene.EndGameDetection
{
    public interface IEndGameDetectionTarget
    {
        public event Action Consumed;
    }
}