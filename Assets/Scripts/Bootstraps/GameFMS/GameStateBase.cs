namespace SourceCode.Bootstraps.GameFMS
{
    public abstract class GameStateBase
    {
        public abstract void Enter();
        public abstract void Exit();
        public abstract void ManualUpdate();
        public abstract void ManualFixedUpdate();
    }
}