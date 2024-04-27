using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.Enemies.Factory
{
    public class EnemiesFactory : MonoBehaviour
    {
        [Inject] private readonly EnemiesFactoryConfig _config;
        [Inject] private readonly DiContainer _container;

        public event Action<Enemy> OnCreate; 
        
        public Enemy Create(Vector2 position, float modelRotation, float scale, Vector2 moveDirection)
        {
            var newEnemy = _container
                .InstantiatePrefab(_config.EnemyPrefab, position, quaternion.identity, transform)
                .GetComponent<Enemy>();
            
            newEnemy.transform.localScale = Vector3.forward + (Vector3)(Vector2.one * scale);
            newEnemy.Initialize(moveDirection, modelRotation);

            OnCreate?.Invoke(newEnemy);
            return newEnemy;
        }
    }
}