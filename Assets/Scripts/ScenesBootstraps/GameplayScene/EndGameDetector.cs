using System;
using SourceCode.Entities;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Entities.StaticEatableObjects.EnvironmentSpawning;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class EndGameDetector
    {
        private readonly GameEndDetectorConfig _config;
        private readonly StaticEatableObjectsRepository _staticEatableObjectsRepository;
        
        private float _initialStaticObjectsSize;
        private float _currentStaticObjectsSize;
        
        public event Action GameEnded;
        
        public EndGameDetector(GameEndDetectorConfig config, EntityBase entity, EnvironmentGenerator environmentGenerator, 
            StaticEatableObjectsRepository staticEatableObjectsRepository)
        {
            _config = config;
            
            _staticEatableObjectsRepository = staticEatableObjectsRepository;
            _staticEatableObjectsRepository.RemovedEatableObjects += OnRemoveStaticEatableObject;
            
            environmentGenerator.Generated += OnLevelGenerated;
            
            entity.OnConsumed += () => GameEnded?.Invoke();
        }

        private void OnLevelGenerated()
        {
            var fullSize = 0f;
            foreach (var consumedObject in _staticEatableObjectsRepository.EatableObjects)
                fullSize += consumedObject.Size;
            
            _currentStaticObjectsSize = _initialStaticObjectsSize = fullSize;
        }

        private void OnRemoveStaticEatableObject(StaticEatableObject staticEatableObject)
        {
            _currentStaticObjectsSize -= staticEatableObject.Size;
            var currentStaticObjectConsumedPercentage = 1 - _currentStaticObjectsSize / _initialStaticObjectsSize;
            if (currentStaticObjectConsumedPercentage >= _config.StaticObjectsConsumedPercentageForEnd)
                GameEnded?.Invoke();
        }
    }
}