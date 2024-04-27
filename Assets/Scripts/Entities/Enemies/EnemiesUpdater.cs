using System.Collections.Generic;
using GameCycleFramework;
using SourceCode.Entities.Enemies.Factory;
using UnityEngine;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesUpdater : IGameCycleUpdate
    {
        private readonly EnemiesFactory _factory;
        private readonly List<Enemy> _enemies = new();

        public EnemiesUpdater(IGameCycleController gameCycleController, EnemiesFactory factory)
        {
            _factory = factory;
            gameCycleController.AddListener(GameCycleState.Gameplay, this);
            _factory.OnCreate += Add;
        }

        public void GameCycleUpdate()
        {
            var time = Time.deltaTime;
            for (int i = 0; i < _enemies.Count; i++)
                _enemies[i].ManualUpdate(time);
        }

        private void Add(Enemy enemy)
        {
            if(_enemies.Contains(enemy))
                Debug.LogError($"Duplicate of {enemy}");
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