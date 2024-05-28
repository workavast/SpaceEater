using System;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects.Factory
{
    public interface IStaticEatableObjectsFactory
    {
        public event Action<StaticEatableObject> OnCreate;

        public StaticEatableObject Create(StaticEatableObjectType staticEatableObjectType, Vector2 position,
            float scale, float rotation);
    }
}