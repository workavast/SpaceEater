using SourceCode.Entities.Enemies.Factory;
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
            if (useEnemiesSpawner)
                Container.BindInterfacesAndSelfTo<EnemiesSpawner>().FromNew().AsSingle();
            else
                Container.BindInterfacesAndSelfTo<UnActiveEnemiesSpawner>().FromNew().AsSingle();
        }
    }
}