using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Entities.Enemies.Spawning
{
    [CreateAssetMenu(fileName = nameof(EnemiesSpawnConfig), menuName = "Configs/" + nameof(EnemiesSpawnConfig))]
    public class EnemiesSpawnConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField, Range(0, 1)] private float spawnChance;
        [SerializeField, Range(0, 180)] private float moveAngle;
        [SerializeField, Range(0, 180)] private float modelRotation;
        [SerializeField, Range(0, 1000)] private float spawnPercentageStep;
        [SerializeField, Range(0, 100)] private float minDistanceFromPlayer;
        [SerializeField, Range(0, 100)] private float maxDistanceFromPlayer;
        [SerializeField, Range(0, 1000)] private float minScalePercentage;
        [SerializeField, Range(0, 1000)] private float maxScalePercentage;

        public float SpawnChance => spawnChance;
        public float MoveAngle => moveAngle;
        public float ModelRotation => modelRotation;
        public float SpawnPercentageStep => spawnPercentageStep/100;
        public float MinDistanceFromPlayer => minDistanceFromPlayer;
        public float MaxDistanceFromPlayer => maxDistanceFromPlayer;
        public float MinScalePercentage => minScalePercentage/100;
        public float MaxScalePercentage => maxScalePercentage/100;
        
        private float _prevMaxDistanceFromPlayer;
        private float _prevMaxScale;
        
        private void OnValidate()
        {
            ClampValue(ref maxDistanceFromPlayer, ref minDistanceFromPlayer, ref _prevMaxDistanceFromPlayer);
            ClampValue(ref maxScalePercentage, ref minScalePercentage, ref _prevMaxScale);
        }
        
        private static void ClampValue(ref float maxValue, ref float minValue, ref float prevValue)
        {
            if (maxValue < minValue)
            {
                if (prevValue > maxValue)
                    minValue = maxValue;
                else
                    maxValue = minValue;
            }
        
            prevValue = maxValue;
        }
    }
}