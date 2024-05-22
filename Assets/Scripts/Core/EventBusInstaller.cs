using EventBusFramework;
using Zenject;

namespace SourceCode.Core
{
    public class EventBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().FromNew().AsSingle();
        }
    }
}