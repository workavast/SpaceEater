using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SourceCode.Core;
using SourceCode.Entities.StaticEatableObjects.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SourceCode.Entities.StaticEatableObjects.EnvironmentGeneration
{
    public class EnvironmentGenerator : IEnvironmentGenerator
    {
        private readonly EnvironmentSpawnConfig _config;
        private readonly StaticEatableObjectsFactory _factory;

        public event Action Generated;
        
        public EnvironmentGenerator(EnvironmentSpawnConfig config, StaticEatableObjectsFactory factory)
        {
            _config = config;
            _factory = factory;
        }

        //TODO: spawn more big objects early then more small objects??
        //TODO: chunks??
        public void Generate()
        {
            List<(StaticEatableObjectType, Vector2, float, float)> spawnTuples = new();
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

                    Vector2 position = Vector2.zero.GetPointOnCircle(cell.MinDistance, cell.MaxDistance);
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
                    
                    var angle = Random.Range(cell.MinAngle, cell.MaxAngle);
                    spawnTuples.Add((cell.StaticEatableObjectType, position, scale, angle));
                }
            }
            
            //TODO: remove coroutine throw factory;
            _factory.StartCoroutine(ApplyGeneration(spawnTuples));
        }
        
        private IEnumerator ApplyGeneration(List<(StaticEatableObjectType, Vector2, float, float)> spawnTuples)
        {
            for (int i = 0; i < spawnTuples.Count; i++)
            {
                var tuple = spawnTuples[i];
                _factory.Create(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
                
                if (i % 50 == 0)
                    yield return Task.Delay(60);
            }
            
            Generated?.Invoke();
        }

        // private async Task ApplyGeneration(List<(StaticEatableObjectType, Vector2, float, float)> spawnTuples)
        // {
        //     for (int i = 0; i < spawnTuples.Count; i++)
        //     {
        //         var tuple = spawnTuples[i];
        //         _factory.Create(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        //         
        //         if (i % 50 == 0)
        //             await Task.Delay(50);
        //     }
        //     
        //     Generated?.Invoke();
        // }
    }
}