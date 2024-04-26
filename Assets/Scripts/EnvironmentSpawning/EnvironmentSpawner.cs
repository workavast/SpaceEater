using System.Collections.Generic;
using SourceCode.Entities.EatableObject;
using SourceCode.Entities.EatableObject.Factory;
using SourceCode.EnvironmentSpawning;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SourceCode
{
    public class EnvironmentSpawner
    {
        private readonly EnvironmentSpawnConfig _config;
        private readonly EatableObjectsFactory _factory;
        
        public EnvironmentSpawner(EnvironmentSpawnConfig config, EatableObjectsFactory factory)
        {
            _config = config;
            _factory = factory;
        }

        //TODO: spawn more bigs objects early then more small objects
        //TODO: chunks??
        public void Generate()
        {
            List<(EatableObjectType, Vector2, float)> spawnTuples = new();
            foreach (var cell in _config.Cells)
            {
                int count = Random.Range(cell.MinCount, cell.MaxCount);

                int iterationsCounter = 0;
                int iterationMaxCount = _config.IterationsMaxCount + cell.MaxCount;
                for (int i = 0; i < count; i++)
                {
                    iterationsCounter++;
                    if (iterationsCounter > iterationMaxCount)
                    {
                        Debug.LogWarning("Too much iterations");
                        Generate();
                        return;
                    }

                    Vector2 position = Vector2Extension.GetPointOnCircle(Vector2.zero, cell.MinDistance, cell.MaxDistance);
                    var scale = Random.Range(cell.MinScale, cell.MaxScale);

                    bool overlap = false;
                    foreach (var tuple in spawnTuples)
                    {
                        if (Vector2.Distance(position, tuple.Item2) <= scale + tuple.Item3)
                        {
                            overlap = true;
                            break;
                        }
                    }

                    if (overlap)
                    {
                        i--;
                        continue;
                    }
                    
                    spawnTuples.Add((cell.EatableObjectType, position, scale));
                }
            }
            
            ApplyGeneration(spawnTuples);
        }

        private void ApplyGeneration(List<(EatableObjectType, Vector2, float)> spawnTuples)
        {
            foreach (var tuple in spawnTuples)
            {
                var newEatableObject = _factory.Create(tuple.Item1, tuple.Item2);
                newEatableObject.transform.localScale = new Vector3(tuple.Item3, tuple.Item3, 1);
            }
        }
    }
}