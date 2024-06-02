using SourceCode.Ad.AdControllers.Android;
using SourceCode.Ad.AdControllers.YandexGames;
using UnityEngine;
using Zenject;

namespace SourceCode.Ad.AdControllers
{
    public sealed class AdInstaller : MonoInstaller
    {
        [SerializeField, Tooltip("Dont hide ad between scenes in WebGl")] 
        private bool useAd = true;

        public override void InstallBindings()
        {
            BindMainAdController();
        }

        private void BindMainAdController()
        {
            if(useAd)
#if PLATFORM_WEBGL
                Container.BindInterfacesTo<YandexGamesAd>().FromNew().AsSingle().NonLazy();
#elif PLATFORM_ANDROID
                Container.BindInterfacesTo<AndroidAd>().FromNew().AsSingle().NonLazy();
#endif
            else
                Container.BindInterfacesTo<UnActiveAdController>().FromNew().AsSingle();
        }
    }
}