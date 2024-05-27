using SourceCode.ConfigsCore;
using UnityEngine;

namespace SourceCode.Entities.Enemies
{
    [CreateAssetMenu(fileName = nameof(EnemiesConfig), menuName = "Configs/" + nameof(EnemiesConfig))]
    public class EnemiesConfig : EatableObjectConfigBase, ISingleConfig
    {
        [field: SerializeField, Range(0, 10)] public float MoveSpeed { get; private set; }
    }
}