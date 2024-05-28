using SourceCode.Entities.StaticEatableObjects.Factory;
using SourceCode.Entities.StaticEatableObjects.StaticEatableObjectsBySizeRemoving;
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
            StaticEatableObjectsBySizeRemoverBinding();
        }

        private void StaticEatableObjectsFactoryBinding()
        {
            var factory = FindObjectOfType<StaticEatableObjectsFactory>();
            //TODO: need remove AndSelfTo, but it required in environment generation
            Container.BindInterfacesAndSelfTo(factory.GetType()).FromInstance(factory).AsSingle();
        }

        private void StaticEatableObjectsRepositoryBinding()
        {
            Container.BindInterfacesTo<StaticEatableObjectsRepository>().FromNew().AsSingle();
        }
        
        private void StaticEatableObjectsUpdaterBinding()
        {
            Container.BindInterfacesTo<StaticEatableObjectsUpdater>().FromNew().AsSingle();
        }

        private void StaticEatableObjectsBySizeRemoverBinding()
        {
            Container.BindInterfacesTo<StaticEatableObjectsBySizeRemover>().FromNew().AsSingle().NonLazy();
        }
    }
}