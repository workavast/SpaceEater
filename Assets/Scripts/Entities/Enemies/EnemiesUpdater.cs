using System.Collections.Generic;
using UnityEngine;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesUpdater
    {
        private readonly EnemiesRepository _enemiesRepository;
        private readonly List<Enemy> _buffer = new(8);

        public EnemiesUpdater(EnemiesRepository enemiesRepository)
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