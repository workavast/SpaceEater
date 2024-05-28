using SourceCode.Entities.BlackHole.BlackHoleUpdating;
using UnityEngine;
using Zenject;

namespace SourceCode.Entities.BlackHole
{
    public class BlackHoleInstaller : MonoInstaller
    {
        [SerializeField] private BlackHoleBehaviour blackHoleBehaviour;

        public override void InstallBindings()
        {
            BindBlackHoleBehavior();
            BindBlackHoleUpdater();
        }

        private void BindBlackHoleBehavior()
        {
            Container.BindInterfacesAndSelfTo<BlackHoleBehaviour>().FromInstance(blackHoleBehaviour).AsSingle();
        }

        private void BindBlackHoleUpdater()
        {
            Container.BindInterfacesTo<BlackHoleUpdater>().FromNew().AsSingle();
        }
    }
}