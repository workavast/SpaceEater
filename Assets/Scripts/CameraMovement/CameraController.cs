using Cinemachine;
using SourceCode.Core;
using UnityEngine;
using Zenject;

namespace SourceCode.CameraMovement
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraController : MonoBehaviour
    {
        [Inject] private readonly CameraConfig _config;

        private float _initialSize;
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        private ICameraTarget _cameraTarget;
        
        private void Awake()
        {
            _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            _initialSize = _cinemachineVirtualCamera.m_Lens.OrthographicSize;
        }

        public void SetFollowTarget(ICameraTarget cameraTarget)
        {
            if (_cameraTarget != null)
                _cameraTarget.OnUpdateSize -= UpdateSize;
            
            _cameraTarget = cameraTarget;
            _cinemachineVirtualCamera.Follow = cameraTarget.Transform;
            _cameraTarget.OnUpdateSize += UpdateSize;
            UpdateSize();
        }

        private void UpdateSize()
        {
            _cinemachineVirtualCamera.m_Lens.OrthographicSize = _cameraTarget.Size * _initialSize * _config.OrthographicSizeScale;
        }
    }
}
