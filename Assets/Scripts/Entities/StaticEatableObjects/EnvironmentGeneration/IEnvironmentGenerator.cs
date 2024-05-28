using System;

namespace SourceCode.Entities.StaticEatableObjects.EnvironmentGeneration
{
    public interface IEnvironmentGenerator
    {
        public event Action Generated;

        public void Generate();
    }
}