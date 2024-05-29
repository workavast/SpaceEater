namespace Initializers.Initializing
{
    public class AndroidGameInitializersBuilder : IGameInitializersBuilder
    {
        public InitializerBase[] GetInitializers(GameBootstrap gameBootstrap)
        {
            return new InitializerBase[]{
                new PlayerGlobalDataInitializer(new InitializerBase[]
                {
                    new LocalizationInitializer()
                }),
            };
        }
    }
}