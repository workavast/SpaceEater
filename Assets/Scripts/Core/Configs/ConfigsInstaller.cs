using UnityEngine;
using Zenject;

namespace SourceCode.Core.Configs
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private ConfigsRepository configsRepository;
        
        public override void InstallBindings()
        {
            foreach (var config in configsRepository.Configs)
                Container.Bind(config.GetType()).FromInstance(config).AsSingle();
        }
    }
}