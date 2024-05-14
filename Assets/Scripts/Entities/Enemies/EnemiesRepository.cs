using System.Collections.Generic;
using SourceCode.Entities.Enemies.Factory;
using UnityEngine;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesRepository
    {
        private readonly EnemiesFactory _factory;
        private readonly List<Enemy> _enemies = new();

        public IReadOnlyList<Enemy> Enemies => _enemies;
        
        public EnemiesRepository(EnemiesFactory factory)
        {
            _factory = factory;
            _factory.OnCreate += Add;
        }

        private void Add(Enemy enemy)
        {
            if(_enemies.Contains(enemy))
                Debug.LogWarning($"Duplicate of {enemy}");
            else
            {
                enemy.OnRemove += Remove;
                _enemies.Add(enemy);
            }
        }

        private void Remove(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }
    }
}