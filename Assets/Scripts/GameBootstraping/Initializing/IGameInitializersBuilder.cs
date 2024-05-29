namespace Initializers.Initializing
{
    public interface IGameInitializersBuilder
    {
        public InitializerBase[] GetInitializers(GameBootstrap gameBootstrap);
    }
}