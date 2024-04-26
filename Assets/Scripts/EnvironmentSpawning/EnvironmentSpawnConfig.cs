using System;
using System.Collections.Generic;
using SourceCode.Core.Configs;
using SourceCode.Entities.EatableObject;
using UnityEngine;

namespace SourceCode.EnvironmentSpawning
{
    [CreateAssetMenu(fileName = nameof(EnvironmentSpawnConfig), menuName = "Configs/" + nameof(EnvironmentSpawnConfig))]
    public class EnvironmentSpawnConfig : ScriptableObject, ISingleConfig
    {
        [field: SerializeField, Range(0, 10000)] public int IterationsMaxCount { get; private set; }
        [SerializeField] private List<Cell> cells;

        public IEnumerable<Cell> Cells => cells;

        private void OnValidate()
        {
            foreach (var cell in cells)
                cell.Validate();
        }
    }

    [Serializable]
    public class Cell
    {
        [field: SerializeField] public EatableObjectType EatableObjectType { get; private set; }
        [field: SerializeField, Range(0, 100000)] public float MinDistance { get; private set; }
        [field: SerializeField, Range(0, 100000)] public float MaxDistance { get; private set; }
        [field: SerializeField, Range(0, 1000)] public int MinCount { get; private set; }
        [field: SerializeField, Range(0, 1000)] public int MaxCount { get; private set; }
        [field: SerializeField, Range(0, 1000)] public float MinScale { get; private set; }
        [field: SerializeField, Range(0, 1000)] public float MaxScale { get; private set; }
        
        private float _prevMaxDistance = 0;
        private float _prevMaxCount = 0;
        private float _prevMaxScale = 0;
        
        public void Validate()
        {
            if (MaxDistance < MinDistance)
            {
                if (_prevMaxDistance > MaxDistance)
                    MinDistance = MaxDistance;
                else
                    MaxDistance = MinDistance;
            }
            
            if (MaxCount < MinCount)
            {
                if (_prevMaxCount > MaxCount)
                    MinCount = MaxCount;
                else
                    MaxCount = MinCount;
            }
            
            if (MaxScale < MinScale)
            {
                if (_prevMaxScale > MaxScale)
                    MinScale = MaxScale;
                else
                    MaxScale = MinScale;
            }

            _prevMaxDistance = MaxDistance;
            _prevMaxCount = MaxCount;
            _prevMaxScale = MaxScale;
        }  
    }
}