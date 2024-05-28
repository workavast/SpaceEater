using SourceCode.Entities.Enemies.Factory;
using SourceCode.Entities.Enemies.Repository;
using SourceCode.Entities.Enemies.Spawning;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.Enemies
{
    public class EnemiesInstaller : MonoInstaller
    {
        [SerializeField] private bool useEnemiesSpawner = true;
        
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
            Container.BindInterfacesTo(factory.GetType()).FromInstance(factory).AsSingle();   
        }

        private void EnemiesRepositoryBinding()
        {
            Container.BindInterfacesTo<EnemiesRepository>().FromNew().AsSingle();
        }

        private void EnemiesUpdaterBinding()
        {
            Container.BindInterfacesTo<EnemiesUpdater>().FromNew().AsSingle();
        }
        
        private void EnemiesSpawnerBinding()
        {
            if (useEnemiesSpawner)
                Container.BindInterfacesTo<EnemiesSpawner>().FromNew().AsSingle();
            else
                Container.BindInterfacesTo<UnActiveEnemiesSpawner>().FromNew().AsSingle();
        }
    }
}