using Zenject;

namespace SourceCode.Localization
{
    public class LocalizationManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LocalizationManager>().FromNew().AsSingle();
        }
    }
}