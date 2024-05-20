using Zenject;

namespace SourceCode.ScenesBootstraps.GameplayScene.Context
{
    public class GameplaySceneContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameplaySceneContext>().FromNew().AsSingle();
        }
    }
}