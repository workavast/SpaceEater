namespace SourceCode.Entities.BlackHole.BlackHoleUpdating
{
    public interface IBlackHoleUpdater
    {
        public bool PlayerIsAlive { get; }
        
        public void ManualUpdate();
    }
}