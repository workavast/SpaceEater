using SourceCode.ConfigsCore;
using UnityEngine;

namespace SourceCode.Entities.Enemies.Factory
{
    [CreateAssetMenu(fileName = nameof(EnemiesFactoryConfig), menuName = "Configs/" + nameof(EnemiesFactoryConfig))]
    public class EnemiesFactoryConfig : ScriptableObject, ISingleConfig
    {
        [SerializeField] private Enemy enemyPrefab;

        public Enemy EnemyPrefab => enemyPrefab;
    }
}