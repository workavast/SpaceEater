using SourceCode.Core.Configs;
using UnityEngine;

namespace SourceCode.Entities.StaticEatableObjects
{
    [CreateAssetMenu(fileName = nameof(StaticEatableObjectConfig), menuName = "Config/" + nameof(StaticEatableObjectConfig))]
    public class StaticEatableObjectConfig : EatableObjectConfigBase, ISingleConfig
    {
        
    }
}