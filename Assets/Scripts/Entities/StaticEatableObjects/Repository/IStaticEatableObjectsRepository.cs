using System;
using System.Collections.Generic;

namespace SourceCode.Entities.StaticEatableObjects
{
    public interface IStaticEatableObjectsRepository
    {
        public IReadOnlyList<StaticEatableObject> EatableObjects { get; }

        public event Action<StaticEatableObject> RemovedEatableObjects;
    }
}