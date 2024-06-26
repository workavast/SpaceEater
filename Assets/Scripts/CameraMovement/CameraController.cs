using System;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace SourceCode.CameraMovement
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraController : MonoBehaviour
    {
        private CameraConfig _config;
        private CameraLensSizeUpdater _cameraLensSizeUpdater;
        private CinemachineVirtualCamera _cinemachineVirtualCamera;

        [Inject]
        public void Construct(CameraConfig config)
        {
            _config = config;
        }
        
        private void Awake()
        {
            _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            
            _cameraLensSizeUpdater = new CameraLensSizeUpdater(_cinemachineVirtualCamera, _config);
        }

        public void SetFollowTarget(ICameraTarget newTarget)
        {
            if (newTarget == null)
                throw new NullReferenceException($"newTarget is null");
            
            _cameraLensSizeUpdater.SetTarget(newTarget);
            _cinemachineVirtualCamera.Follow = newTarget.Transform;
        }
    }
}
