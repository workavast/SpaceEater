using Zenject;

namespace SourceCode.Entities.StaticEatableObjects.EnvironmentGeneration
{
    public class EnvironmentGeneratorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnvironmentGenerator>().FromNew().AsSingle();
        }
    }
}