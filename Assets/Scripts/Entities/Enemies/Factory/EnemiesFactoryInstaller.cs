using Zenject;

namespace SourceCode.Entities.Enemies.Factory
{
    public class EnemiesFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var factory = FindObjectOfType<EnemiesFactory>();
            Container.BindInstance(factory).AsSingle();
        }
    }
}