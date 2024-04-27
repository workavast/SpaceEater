using SourceCode.Core;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies.Factory;
using UnityEngine;

namespace SourceCode.Entities.Enemies.Spawning
{
    public class EnemiesSpawner
    {
        private readonly EnemiesSpawnConfig _config;
        private readonly EnemiesFactory _factory;
        private readonly BlackHoleBehaviour _blackHoleBehaviour;

        private float _blackHolePrevSize;
        
        public EnemiesSpawner(EnemiesSpawnConfig config, EnemiesFactory factory, BlackHoleBehaviour blackHoleBehaviour)
        {
            _config = config;
            _factory = factory;
            _blackHoleBehaviour = blackHoleBehaviour;

            _blackHoleBehaviour.OnUpdateSize += TrySpawnEnemy;
            _blackHolePrevSize = _blackHoleBehaviour.Size;
        }

        private void TrySpawnEnemy()
        {
            var blackHoleSize = _blackHoleBehaviour.Size;
            var curStep = blackHoleSize / _blackHolePrevSize - 1;

            if (!(curStep >= _config.SpawnPercentageStep)) 
                return;

            var spawnChance = Random.Range(0f, 1f);
            if(spawnChance > _config.SpawnChance)
                return;

            var blackHolePosition = (Vector2)_blackHoleBehaviour.transform.position;
            var enemySpawnPosition = blackHolePosition.GetPointOnCircle(_config.MinDistanceFromPlayer * blackHoleSize, _config.MaxDistanceFromPlayer * blackHoleSize);
            var enemyAdditionalScale = Random.Range(blackHoleSize * _config.MinScalePercentage, blackHoleSize * _config.MaxScalePercentage);
            var enemyMoveDirectionAngle = Random.Range(-_config.MoveAngle, _config.MoveAngle);
                
            var enemyMoveDirection = (blackHolePosition - enemySpawnPosition).normalized;
            enemyMoveDirection = Quaternion.Euler(0, 0, enemyMoveDirectionAngle) * enemyMoveDirection;
            
            var enemyRotation = Random.Range(-_config.ModelRotation, _config.ModelRotation);

            _factory.Create(enemySpawnPosition, enemyRotation, blackHoleSize + enemyAdditionalScale, enemyMoveDirection);
                
            _blackHolePrevSize = _blackHoleBehaviour.Size;
        }
    }
}