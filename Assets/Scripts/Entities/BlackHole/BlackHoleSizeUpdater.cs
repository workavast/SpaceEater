using DG.Tweening;

namespace SourceCode.Entities.BlackHole
{
    public class BlackHoleSizeUpdater
    {
        private readonly BlackHoleBehaviour _blackHole;
        private readonly BlackHoleConfig _config;

        private Tween _tween;
        
        public BlackHoleSizeUpdater(BlackHoleBehaviour blackHole, BlackHoleConfig config)
        {
            _blackHole = blackHole;
            _config = config;
        }
        
        public void IncreaseSize()
        {
            if(_tween.IsActive())
                _tween.Kill();

            _tween = _blackHole.transform
                .DOScale(_blackHole.TargetSize, _config.ChangeScaleDuration)
                .SetLink(_blackHole.gameObject)
                .SetEase(_config.ChangeScaleEaseType)
                .OnKill(() => _tween = null);
        }
    }
}