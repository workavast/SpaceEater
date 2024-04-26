using GameCycleFramework;
using UnityEngine;
using Zenject;

namespace SourceCode.GameCycleAdditions
{
    public class GameCycleUpdater : MonoBehaviour
    {
        [SerializeField] private GameCycleState initialGameCycleState = GameCycleState.Gameplay;
        
        [Inject] private readonly GameCycleController _gameCycleController;

        private float _deltaTimeScale = 1;
        private float _fixedDeltaTimeScale = 1;
        
        private void Awake()
            =>_gameCycleController.Initialize(initialGameCycleState);

        private void Update()
            => _gameCycleController.ManualUpdate(Time.deltaTime);

        private void FixedUpdate()
            => _gameCycleController.ManualFixedUpdate(Time.fixedDeltaTime);

        public void SetDeltaTimeScale(float newDeltaTimeScale)
            => _deltaTimeScale = newDeltaTimeScale;
        
        public void SetFixedDeltaTimeScale(float newFixedDeltaTimeScale)
            => _fixedDeltaTimeScale = newFixedDeltaTimeScale;
    }
}