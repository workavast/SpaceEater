using Zenject;

namespace SourceCode.ScenesBootstraps.GameplayScene.EndGameDetection
{
    public class EndGameDetectorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EndGameDetector>().FromNew().AsSingle();
        }
    }
}