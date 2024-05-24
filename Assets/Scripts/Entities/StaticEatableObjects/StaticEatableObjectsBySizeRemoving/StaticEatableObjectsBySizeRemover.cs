using System.Collections.Generic;
using SourceCode.Entities.BlackHole;

namespace SourceCode.Entities.StaticEatableObjects.StaticEatableObjectsBySizeRemoving
{
    public class StaticEatableObjectsBySizeRemover : IStaticEatableObjectsBySizeRemover
    {
        private readonly StaticEatableObjectsBySizeRemoverConfig _config;
        private readonly StaticEatableObjectsRepository _repository;
        private readonly BlackHoleBehaviour _blackHoleBehaviour;
        private readonly List<StaticEatableObject> _objectsForDeleting = new(64);
        
        public StaticEatableObjectsBySizeRemover(StaticEatableObjectsBySizeRemoverConfig config, 
            StaticEatableObjectsRepository repository, BlackHoleBehaviour blackHoleBehaviour)
        {
            _config = config;
            _repository = repository;
            _blackHoleBehaviour = blackHoleBehaviour;

            _blackHoleBehaviour.OnUpdateTargetSize += CheckOnSmallObjectsExist;
        }
        
        private void CheckOnSmallObjectsExist()
        {
            _objectsForDeleting.Clear();
            foreach (var obj in _repository.EatableObjects)
            {
                if (_blackHoleBehaviour.TargetSize / obj.Size >= _config.ScaleDifference)
                    _objectsForDeleting.Add(obj);
            }

            foreach (var obj in _objectsForDeleting)
                obj.ManualRemoveStaticEatableObject();
            _objectsForDeleting.Clear();
        }
    }
}