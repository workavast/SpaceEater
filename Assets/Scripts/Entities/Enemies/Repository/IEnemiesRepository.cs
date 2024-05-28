using System.Collections.Generic;

namespace SourceCode.Entities.Enemies.Repository
{
    public interface IEnemiesRepository
    {
        public IReadOnlyList<Enemy> Enemies { get; }
    }
}