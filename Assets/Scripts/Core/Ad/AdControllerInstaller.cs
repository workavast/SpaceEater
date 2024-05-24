using UnityEngine;
using Zenject;

namespace SourceCode.Core.Ad
{
    public class AdControllerInstaller : MonoInstaller
    {
        [SerializeField] private bool useAd;
        
        public override void InstallBindings()
        {
            if(useAd)
                Container.BindInterfacesAndSelfTo<AdController>().FromNew().AsSingle();
            else
                Container.BindInterfacesAndSelfTo<UnActiveAdController>().FromNew().AsSingle();
        }
    }
}