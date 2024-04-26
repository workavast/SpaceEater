using GameCycleFramework;
using SourceCode.BackgroundControl;
using SourceCode.CameraMovement;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.EatableObject;
using SourceCode.Entities.EatableObject.Factory;
using SourceCode.EnvironmentSpawning;
using UnityEngine;
using Zenject;

namespace SourceCode.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private BackgroundController backgroundController;
        [SerializeField] private BlackHoleBehaviour blackHoleBehaviour;

        [Inject] private readonly IGameCycleController _gameCycleController;
        [Inject] private readonly EatableObjectsFactory _eatableObjectsFactory;
        [Inject] private readonly EnvironmentSpawnConfig _environmentSpawnConfig;
        
        private EatableObjectsUpdater _eatableObjectsUpdater;
        private EnvironmentSpawner _spawner;
        
        private void Start()
        {
            FpsCap.Initialize();
            cameraController.SetFollowTarget(blackHoleBehaviour);
            backgroundController.SetTarget(blackHoleBehaviour);
            _eatableObjectsUpdater = new EatableObjectsUpdater(_gameCycleController, _eatableObjectsFactory);
            _spawner = new EnvironmentSpawner(_environmentSpawnConfig, _eatableObjectsFactory);
            _spawner.Generate();
        }
    }
}