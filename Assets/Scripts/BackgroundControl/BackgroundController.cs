using UnityEngine;
using Zenject;

namespace SourceCode.BackgroundControl
{
    public class BackgroundController : MonoBehaviour
    {
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject stars;
        
        [Inject] private readonly BackgroundConfig _config;
        
        private IBackgroundTarget _target;
        
        public void SetTarget(IBackgroundTarget newTarget)
        {
            if (_target != null)
            {
                _target.OnUpdateSize -= UpdateSize;
                _target.OnMove -= Move;
            }
            
            _target = newTarget;
            _target.OnUpdateSize += UpdateSize;
            _target.OnMove += Move;
            UpdateSize();

            var direction = (_target.Transform.position - transform.position).normalized;
            var distance = Vector2.Distance(_target.Transform.position, transform.position);
            Move(direction, distance);
        }

        private void Move(Vector2 direction, float distance)
        {
            var velocity = direction * (distance * _config.MoveSpeed);
            transform.Translate(velocity);
            background.transform.Translate(velocity * _config.BackgroundMoveScale);
            stars.transform.Translate(velocity * _config.StarsMoveScale);
        }
        
        private void UpdateSize()
        {
            transform.localScale = Vector3.forward + (Vector3)(Vector2.one * Mathf.Pow(_target.Size, _config.SizeScaler));
        }
    }
}