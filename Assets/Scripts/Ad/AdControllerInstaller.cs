using UnityEngine;
using Zenject;

namespace SourceCode.Ad
{
    public class AdControllerInstaller : MonoInstaller
    {
        [SerializeField] private bool useAd;
        
        public override void InstallBindings()
        {
            if(useAd)
                Container.BindInterfacesTo<AdController>().FromNew().AsSingle();
            else
                Container.BindInterfacesTo<UnActiveAdController>().FromNew().AsSingle();
        }
    }
}