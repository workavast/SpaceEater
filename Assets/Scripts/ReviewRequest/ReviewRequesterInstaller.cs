using Zenject;

namespace SourceCode.ReviewRequest
{
    public class ReviewRequesterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<YandexGamesReviewRequester>().FromNew().AsSingle();
        }
    }
}