using System.Linq;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects
{
    public class StaticEatableObjectsUpdater
    {
        private readonly StaticEatableObjectsRepository _staticEatableObjectsRepository;

        public StaticEatableObjectsUpdater(StaticEatableObjectsRepository staticEatableObjectsRepository)
        {
            _staticEatableObjectsRepository = staticEatableObjectsRepository;
        }

        public void ManualUpdate()
        {
            var time = Time.deltaTime;
            var objects = _staticEatableObjectsRepository.EatableObjects.ToList();
            for (int i = 0; i < objects.Count; i++)
                objects[i].ManualUpdate(time);
        }
    }
}