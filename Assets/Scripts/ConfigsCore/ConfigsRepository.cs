using System.Collections.Generic;
using UnityEngine;

namespace SourceCode.ConfigsCore
{
    [CreateAssetMenu(fileName = nameof(ConfigsRepository), menuName = "Configs/" + nameof(ConfigsRepository))]
    public class ConfigsRepository : ScriptableObject
    {
        [SerializeField] private List<ScriptableObject> _scriptableObjects;

        public IEnumerable<ScriptableObject> Configs => _scriptableObjects;
        
        // TODO: fix it: doesnt work in build
        // private Dictionary<Type, ISingleConfig> _configsDictionary;
        // private static readonly List<ScriptableObject> ConfigsList = new();
        // private List<ScriptableObject> _configsVisualisation = new();
        // public IEnumerable<ISingleConfig> Configs => _configsDictionary.Values;

// #if UNITY_EDITOR
//         private void OnEnable() 
//             => Refresh();
//
//         private void Refresh()
//         {
//             _configsVisualisation = ConfigsList;
//             _configsDictionary = new Dictionary<Type, ISingleConfig>(ConfigsList.Count);
//
//             foreach (var config in ConfigsList)
//             {
//                 if(config is not ISingleConfig singleConfig)
//                     continue;
//                 
//                 if(config == this)
//                     continue;
//
//                 var type = singleConfig.GetType();
//
//                 if (_configsDictionary.ContainsKey(type))
//                     Debug.LogError($"Duplicate of {type} {config}");
//                 else
//                     _configsDictionary.Add(type, singleConfig);
//             }
//         }
//
//         [InitializeOnLoadMethod]
//         private static void RefreshConfigsList()
//         {
//             var configs = Resources.LoadAll<ScriptableObject>("Configs");
//
//             var singleConfigs = configs.Where(c => c is ISingleConfig);
//             
//             ConfigsList.Clear();
//             foreach (var singConfig in singleConfigs)
//                 ConfigsList.Add(singConfig);
//         }
// #endif
    }
}