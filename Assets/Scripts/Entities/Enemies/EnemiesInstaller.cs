using SourceCode.Entities.Enemies.Factory;
using SourceCode.Entities.Enemies.Spawning;
using Zenject;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            EnemiesFactoryBinding();
            EnemiesRepositoryBinding();
            EnemiesUpdaterBinding();
            EnemiesSpawnerBinding();
        }

        private void EnemiesFactoryBinding()
        {
            var factory = FindObjectOfType<EnemiesFactory>();
            Container.BindInstance(factory).AsSingle();   
        }

        private void EnemiesRepositoryBinding()
        {
            Container.BindInterfacesAndSelfTo<EnemiesRepository>().FromNew().AsSingle();
        }

        private void EnemiesUpdaterBinding()
        {
            Container.BindInterfacesAndSelfTo<EnemiesUpdater>().FromNew().AsSingle();
        }
        
        private void EnemiesSpawnerBinding()
        {
            Container.BindInterfacesAndSelfTo<EnemiesSpawner>().FromNew().AsSingle();
        }
    }
}