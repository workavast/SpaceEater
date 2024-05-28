using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.Enemies.Factory
{
    public class EnemiesFactory : MonoBehaviour, IEnemyFactory
    {
        private EnemiesFactoryConfig _config;
        private DiContainer _diContainer;

        public event Action<Enemy> OnCreate; 
        
        [Inject]
        public void Construct(EnemiesFactoryConfig config, DiContainer diContainer)
        {
            _config = config;
            _diContainer = diContainer;
        }
        
        public Enemy Create(Vector2 position, float modelRotation, float scale, Vector2 moveDirection)
        {
            var newEnemy = _diContainer
                .InstantiatePrefab(_config.EnemyPrefab, position, quaternion.identity, transform)
                .GetComponent<Enemy>();
            
            newEnemy.transform.localScale = Vector3.forward + (Vector3)(Vector2.one * scale);
            newEnemy.Initialize(moveDirection, modelRotation);

            OnCreate?.Invoke(newEnemy);
            return newEnemy;
        }
    }
}