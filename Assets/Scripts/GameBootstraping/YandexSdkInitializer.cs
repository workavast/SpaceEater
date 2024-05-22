using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using YG;

namespace Initializers
{
    public class YandexSdkInitializer : InitializerBase
    {
        private readonly GameBootstrap _gameBootstrap;

        public YandexSdkInitializer(GameBootstrap gameBootstrap, InitializerBase[] initializers = null) 
            : base(initializers)
        {
            _gameBootstrap = gameBootstrap;
        }

        public override void Init()
        {
            Debug.Log($"-||- Init");
            _gameBootstrap.StartCoroutine(WaitLoadCor());
        }

        //Doesnt work in webGl build
        // private async void WaitLoad()
        // {
        //     var curUnScaledTime = Time.unscaledTime;
        //     var dif = 0.51f - curUnScaledTime;
        //
        //     Debug.Log($"-||- WaitLoad {(int)(1000 * dif)} | {dif}");
        //     if (curUnScaledTime >= 0)
        //         await Task.Delay((int)(1000 * dif));
        //     
        //     while (!YandexGame.SDKEnabled)
        //     {
        //         Debug.Log("Await");
        //         await Task.Delay(50);
        //     }
        //     
        //     Debug.Log("-||- YandexSdkInitializer");
        //     OnParentInit?.Invoke();
        // }
        
        IEnumerator WaitLoadCor()
        {
            var curUnScaledTime = Time.unscaledTime;
            var dif = 0.51f - curUnScaledTime;

            Debug.Log($"-||- WaitLoad {(int)(1000 * dif)} | {dif}");
            if (curUnScaledTime >= 0)
                yield return Task.Delay((int)(1000 * dif));
            
            while (!YandexGame.SDKEnabled)
            {
                Debug.Log("Await");
                yield return Task.Delay(50);
            }
            
            Debug.Log("-||- YandexSdkInitializer");
            OnParentInit?.Invoke();
        }
    }
}