using System;
using UnityEngine;
using Zenject;

namespace SourceCode.BackgroundControl
{
    public class BackgroundController : MonoBehaviour
    {
        [SerializeField] private Transform background;
        [SerializeField] private Transform stars;
        
        private BackgroundConfig _config;
        private BackgroundMover _backgroundMover;
        private BackgroundSizeUpdater _backgroundSizeUpdater;

        [Inject]
        public void Construct(BackgroundConfig config)
        {
            _config = config;
        }
        
        private void Awake()
        {
            _backgroundMover = new BackgroundMover(transform, background, stars, _config);
            _backgroundSizeUpdater = new BackgroundSizeUpdater(transform, _config);
        }

        public void SetTarget(IBackgroundTarget newTarget)
        {
            if (newTarget == null)
                throw new NullReferenceException($"newTarget is null");
            
            _backgroundMover.SetTarget(newTarget);
            _backgroundSizeUpdater.SetTarget(newTarget);
        }
    }
}