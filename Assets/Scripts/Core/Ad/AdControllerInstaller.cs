using SourceCode.ScenesBootstraps.GameplayScene;
using Zenject;

namespace SourceCode.Core.Ad
{
    public class AdControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AdController>().FromNew().AsSingle();
        }
    }
}