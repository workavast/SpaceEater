using GameCycleFramework;
using Zenject;

namespace SourceCode.GameCycleAdditions
{
    public class GameCycleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameCycleController>().FromNew().AsSingle().NonLazy();
        }
    }
}