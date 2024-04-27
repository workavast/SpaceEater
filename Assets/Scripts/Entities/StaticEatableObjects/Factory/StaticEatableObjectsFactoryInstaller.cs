using Zenject;

namespace SourceCode.Entities.StaticEatableObjects.Factory
{
    public class StaticEatableObjectsFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var factory = FindObjectOfType<StaticEatableObjectsFactory>();
            Container.BindInstance(factory).AsSingle();
        }
    }
}