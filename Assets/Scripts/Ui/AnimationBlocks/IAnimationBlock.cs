using System;

namespace SourceCode.Ui.AnimationBlocks
{
    public interface IAnimationBlock
    {
        public bool IsActive { get; }

        public void Show(Action onCompleted);
        public void Hide(Action onCompleted);
    }
}