using Zenject;

namespace SourceCode.Core
{
    public class PlayerControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().FromNew().AsSingle();
        }
    }
}