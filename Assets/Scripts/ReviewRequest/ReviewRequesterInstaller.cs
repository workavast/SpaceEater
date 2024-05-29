using Zenject;

namespace SourceCode.ReviewRequest
{
    public class ReviewRequesterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
#if PLATFORM_WEBGL
            Container.BindInterfacesTo<YandexGamesReviewRequester>().FromNew().AsSingle();
#elif PLATFORM_ANDROID
            Container.BindInterfacesTo<AndroidReviewRequester>().FromNew().AsSingle();
#endif
        }
    }
}