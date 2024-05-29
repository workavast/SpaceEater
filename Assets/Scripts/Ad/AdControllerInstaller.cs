using SourceCode.Ad.Controllers;
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
#if PLATFORM_WEBGL
                Container.BindInterfacesTo<YandexGamesAdController>().FromNew().AsSingle();
#elif PLATFORM_ANDROID
                Container.BindInterfacesTo<AndroidAdController>().FromNew().AsSingle();
#endif
            else
                Container.BindInterfacesTo<UnActiveAdController>().FromNew().AsSingle();
        }
    }
}