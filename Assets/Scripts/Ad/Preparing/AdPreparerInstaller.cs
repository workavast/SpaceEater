using Zenject;

namespace SourceCode.Ad.Preparing
{
    public class AdPreparerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AdPreparer>().FromNew().AsSingle();
        }
    }
}