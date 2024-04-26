using Zenject;

namespace SourceCode.Core.PlayZone
{
    public class PlayZoneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var playZoneBehaviour = FindObjectOfType<PlayZoneBehaviour>();
            Container.BindInstance(playZoneBehaviour).AsSingle();
        }
    }
}