using System.Linq;
using UnityEngine;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesUpdater
    {
        private readonly EnemiesRepository _enemiesRepository;

        public EnemiesUpdater(EnemiesRepository enemiesRepository)
        {
            _enemiesRepository = enemiesRepository;
        }

        public void ManualUpdate()
        {
            var time = Time.deltaTime;
            var enemies = _enemiesRepository.Enemies.ToList();
            
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].ManualUpdate(time);
        }
    }
}