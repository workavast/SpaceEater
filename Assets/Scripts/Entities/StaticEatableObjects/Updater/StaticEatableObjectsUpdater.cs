using System.Collections.Generic;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects
{
    public class StaticEatableObjectsUpdater : IStaticEatableObjectsUpdater
    {
        private readonly IStaticEatableObjectsRepository _staticEatableObjectsRepository;
        private readonly List<StaticEatableObject> _buffer = new List<StaticEatableObject>(1024);

        public StaticEatableObjectsUpdater(IStaticEatableObjectsRepository staticEatableObjectsRepository)
        {
            _staticEatableObjectsRepository = staticEatableObjectsRepository;
        }

        public void ManualUpdate()
        {
            var time = Time.deltaTime;
            _buffer.Clear();
            _buffer.AddRange(_staticEatableObjectsRepository.EatableObjects);
            for (int i = 0; i < _buffer.Count; i++)
                _buffer[i].ManualUpdate(time);
        }
    }
}