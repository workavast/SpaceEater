using DG.Tweening;
using SourceCode.Core;
using UnityEngine;

namespace SourceCode.BackgroundControl
{
    public class BackgroundSizeUpdater
    {
        private readonly Transform _backgroundHolder;
        private readonly BackgroundConfig _config;
        
        private IBackgroundTarget _target;
        private Tween _tween;

        public BackgroundSizeUpdater(Transform backgroundHolder, BackgroundConfig config)
        {
            _backgroundHolder = backgroundHolder;
            _config = config;
        }

        public void SetTarget(IBackgroundTarget target)
        {
            if (_target != null)
                _target.OnUpdateTargetSize -= UpdateSize;
            
            _target = target;
            _target.OnUpdateTargetSize += UpdateSize;
            UpdateSize();
        }

        private void UpdateSize()
        {
            if(_tween.IsActive())
                _tween.Kill();

            var targetSize = Vector2.one * Mathf.Pow(_target.TargetSize, _config.SizeScaler);
            _tween = _backgroundHolder
                .DOScale(targetSize, _config.ChangeScaleDuration)
                .SetLink(_backgroundHolder.gameObject)
                .SetEase(_config.ChangeScaleEaseType)
                .OnKill(() => _tween = null);
        }
    }
}