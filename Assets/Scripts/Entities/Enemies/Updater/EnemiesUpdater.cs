using System.Collections.Generic;
using SourceCode.Entities.Enemies.Repository;
using UnityEngine;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesUpdater : IEnemiesUpdater
    {
        private readonly IEnemiesRepository _enemiesRepository;
        private readonly List<Enemy> _buffer = new(8);

        public EnemiesUpdater(IEnemiesRepository enemiesRepository)
        {
            _enemiesRepository = enemiesRepository;
        }

        public void ManualUpdate()
        {
            var time = Time.deltaTime;
            _buffer.Clear();
            _buffer.AddRange(_enemiesRepository.Enemies);
            for (int i = 0; i < _buffer.Count; i++)
                _buffer[i].ManualUpdate(time);
        }
    }
}