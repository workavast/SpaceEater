using SourceCode.Entities.StaticEatableObjects.Factory;
using Zenject;

namespace SourceCode.Entities.StaticEatableObjects
{
    public class StaticEatableObjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            StaticEatableObjectsFactoryBinding();
            StaticEatableObjectsRepositoryBinding();
            StaticEatableObjectsUpdaterBinding();
        }

        private void StaticEatableObjectsFactoryBinding()
        {
            var factory = FindObjectOfType<StaticEatableObjectsFactory>();
            Container.BindInstance(factory).AsSingle();
        }

        private void StaticEatableObjectsRepositoryBinding()
        {
            Container.Bind<StaticEatableObjectsRepository>().FromNew().AsSingle();
        }
        
        private void StaticEatableObjectsUpdaterBinding()
        {
            Container.Bind<StaticEatableObjectsUpdater>().FromNew().AsSingle();
        }
    }
}