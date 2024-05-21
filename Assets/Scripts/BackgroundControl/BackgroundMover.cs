using SourceCode.Core;
using UnityEngine;

namespace SourceCode.BackgroundControl
{
    public class BackgroundMover
    {
        private readonly Transform _backgroundHolder;
        private readonly Transform _background;
        private readonly Transform _stars;
        private readonly BackgroundConfig _config;
        
        private IBackgroundTarget _target;

        public BackgroundMover(Transform backgroundHolder, Transform background, Transform stars, BackgroundConfig config)
        {
            _backgroundHolder = backgroundHolder;
            _background = background;
            _stars = stars;
            _config = config;
        }
        
        public void SetTarget(IBackgroundTarget newTarget)
        {
            if (_target != null)
                _target.OnMove -= Move;
            
            _target = newTarget;
            _target.OnMove += Move;

            var direction = (_target.Transform.position - _backgroundHolder.position).normalized;
            var distance = Vector2.Distance(_target.Transform.position, _backgroundHolder.position);
            Move(direction, distance);
        }
        
        private void Move(Vector2 direction, float distance)
        {
            var velocity = direction * (distance * _config.MoveSpeed);
            _backgroundHolder.Translate(velocity);
            _background.transform.Translate(velocity * _config.BackgroundMoveScale);
            _stars.transform.Translate(velocity * _config.StarsMoveScale);
        }
    }
}