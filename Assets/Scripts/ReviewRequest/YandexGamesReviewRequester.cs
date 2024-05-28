using YG;

namespace SourceCode.ReviewRequest
{
    public class YandexGamesReviewRequester : IReviewRequester
    {
        public void SendRequest()
        {
            YandexGame.ReviewShow(YandexGame.auth);
        }
    }
}