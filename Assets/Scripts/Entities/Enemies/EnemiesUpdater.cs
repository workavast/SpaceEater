using System.Collections.Generic;
using SourceCode.Entities.Enemies.Factory;
using UnityEngine;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesUpdater
    {
        private readonly EnemiesFactory _factory;
        private readonly List<Enemy> _enemies = new();

        public EnemiesUpdater(EnemiesFactory factory)
        {
            _factory = factory;
            _factory.OnCreate += Add;
        }

        public void ManualUpdate()
        {
            var time = Time.deltaTime;
            for (int i = 0; i < _enemies.Count; i++)
                _enemies[i].ManualUpdate(time);
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