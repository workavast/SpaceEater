using Zenject;

namespace SourceCode.Entities.EatableObject.Factory
{
    public class EatableObjectsFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var factory = FindObjectOfType<EatableObjectsFactory>();
            Container.BindInstance(factory).AsSingle();
        }
    }
}