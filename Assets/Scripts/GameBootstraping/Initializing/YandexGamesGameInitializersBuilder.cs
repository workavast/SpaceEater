namespace Initializers.Initializing
{
    public class YandexGamesGameInitializersBuilder : IGameInitializersBuilder
    {
        public InitializerBase[] GetInitializers(GameBootstrap gameBootstrap)
        {
            return new InitializerBase[]
            {
                new YandexSdkInitializer(gameBootstrap, new InitializerBase[]
                    {
                        new PlayerGlobalDataInitializer(new InitializerBase[]
                        {
                            new LocalizationInitializer()
                        }),
                    }
                )
            };
        }
    }
}