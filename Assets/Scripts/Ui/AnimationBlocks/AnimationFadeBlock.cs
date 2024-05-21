using System;
using DG.Tweening;
using UnityEngine;

namespace SourceCode.Ui.AnimationBlocks
{
    [Serializable]
    public class AnimationFadeBlock : IAnimationBlock
    {
        [SerializeField] private CanvasGroup block;
        [Space]
        [SerializeField] private float showDuration = 0.3f;
        [SerializeField] private Ease easeShow = Ease.OutSine;
        [Space]
        [SerializeField] private float hideDuration = 0.3f;
        [SerializeField] private Ease easeHide = Ease.InSine;

        private Tween _tween;
        
        public bool IsActive => _tween.IsActive();
        
        public void Show(Action onCompleted)
        {
            if (_tween.IsActive())
                _tween.Kill();
            
            block.alpha = 0;
            block.DOFade(1, showDuration)
                .SetLink(block.gameObject)
                .SetEase(easeShow)
                .OnKill(() => _tween = null)
                .OnComplete(() =>
                {
                    _tween = null;
                    onCompleted?.Invoke();
                });
        }

        public void Hide(Action onCompleted)
        {
            if (_tween.IsActive())
                _tween.Kill();
            
            block.alpha = 1;
            _tween = 
                block
                    .DOFade(0, hideDuration)
                    .SetLink(block.gameObject)
                    .SetEase(easeHide)
                    .OnKill(() => _tween = null)
                    .OnComplete(() =>
                    {
                        _tween = null;
                        onCompleted?.Invoke();
                    });
        }
    }
}