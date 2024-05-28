using System;
using UnityEngine;

namespace SourceCode.Entities.Enemies.Factory
{
    public interface IEnemyFactory
    {
        public event Action<Enemy> OnCreate;

        public Enemy Create(Vector2 position, float modelRotation, float scale, Vector2 moveDirection);
    }
}