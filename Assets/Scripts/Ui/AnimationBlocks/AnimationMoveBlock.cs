using System;
using DG.Tweening;
using UnityEngine;

namespace SourceCode.Ui.AnimationBlocks
{
    [Serializable]
    public class AnimationMoveBlock : IAnimationBlock
    {
        [SerializeField] private RectTransform block;
        [Space]
        [SerializeField] private RectTransform showPosition;
        [SerializeField, Min(0)] private float showDuration = 0.3f;
        [SerializeField] private Ease easeShow = Ease.OutSine;
        [Space]
        [SerializeField] private RectTransform hidePosition;
        [SerializeField, Min(0)] private float hideDuration = 0.3f;
        [SerializeField] private Ease easeHide = Ease.InSine;
        
        private Tween _tween;
        
        public bool IsActive => _tween.IsActive();
        
        public void Show(Action onCompleted)
        {
            if (_tween.IsActive())
                _tween.Kill();
            
            block.position = hidePosition.position;
            block
                .DOMove(showPosition.position, showDuration)
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
            
            block.position = showPosition.position;
            _tween = 
                block
                    .DOMove(hidePosition.position, hideDuration)
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