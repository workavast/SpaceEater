using UnityEngine;
using Zenject;

namespace SourceCode.Entities.BlackHole
{
    public class BlackHoleInstaller : MonoInstaller
    {
        [SerializeField] private BlackHoleBehaviour blackHoleBehaviour;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BlackHoleBehaviour>().FromInstance(blackHoleBehaviour).AsSingle();
        }
    }
}