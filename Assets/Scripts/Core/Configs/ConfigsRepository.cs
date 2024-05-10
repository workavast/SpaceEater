using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SourceCode.Core.Configs
{
    [CreateAssetMenu(fileName = nameof(ConfigsRepository), menuName = "Configs/" + nameof(ConfigsRepository))]
    public class ConfigsRepository : ScriptableObject
    {
        [SerializeField] private List<ScriptableObject> configs = new();

        private Dictionary<Type, ISingleConfig> _configs;

        public IEnumerable<ISingleConfig> Configs => _configs.Values;
        
#if UNITY_EDITOR
        private void OnEnable()
            => Refresh();

        private void Refresh()
        {
            _configs = new Dictionary<Type, ISingleConfig>(configs.Count);

            foreach (var config in configs)
            {
                if(config is not ISingleConfig singleConfig)
                    continue;
                
                if(config == this)
                    continue;

                var type = singleConfig.GetType();

                if (_configs.ContainsKey(type))
                    Debug.LogError($"Duplicate of {type} {config}");
                else
                    _configs.Add(type, singleConfig);
            }
        }

        [InitializeOnLoadMethod]
        private static void RefreshConfigsList()
        {
            var configs = Resources.LoadAll<ScriptableObject>("Configs");

            var repositories = configs.OfType<ConfigsRepository>();
            var singleConfigs = configs.Where(c => c is ISingleConfig);
            Debug.Log($"{configs.Length} || {repositories.Count()} || {singleConfigs.Count()}");
            
            foreach (var repository in repositories)
            {
                repository.configs = new List<ScriptableObject>();
                foreach (var singConfig in singleConfigs)
                    repository.configs.Add(singConfig);
            }
        }
#endif
    }
}