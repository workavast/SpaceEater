using CameraMovement;
using Cinemachine;
using DG.Tweening;

namespace SourceCode.CameraMovement
{
    public class CameraLensSizeUpdater
    {
        private readonly CinemachineVirtualCamera _cinemachineVirtualCamera;
        private readonly CameraConfig _config;
        private readonly float _initialSize;
        
        private ICameraTarget _cameraTarget;
        private Tween _tween;

        public CameraLensSizeUpdater(CinemachineVirtualCamera cinemachineVirtualCamera, CameraConfig config)
        {
            _cinemachineVirtualCamera = cinemachineVirtualCamera;
            _config = config;
            _initialSize = _cinemachineVirtualCamera.m_Lens.OrthographicSize;
        }

        public void SetTarget(ICameraTarget cameraTarget)
        {
            if (_cameraTarget != null)
                _cameraTarget.OnUpdateTargetSize -= UpdateCameraLensSize;
            
            _cameraTarget = cameraTarget;
            _cameraTarget.OnUpdateTargetSize += UpdateCameraLensSize;
            UpdateCameraLensSize();
        }

        private void UpdateCameraLensSize()
        {
            if(_tween.IsActive())
                _tween.Kill();
            
            _tween = DOTween.To(
                () => _cinemachineVirtualCamera.m_Lens.OrthographicSize,
                x => _cinemachineVirtualCamera.m_Lens.OrthographicSize = x,
                _cameraTarget.TargetSize * _initialSize * _config.OrthographicSizeScale,
                _config.ChangeScaleDuration)
                .SetLink(_cinemachineVirtualCamera.gameObject)
                .SetEase(_config.ChangeScaleEaseType)
                .OnKill(() => _tween = null);
        }
    }
}