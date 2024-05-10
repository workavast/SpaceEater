using System.Threading.Tasks;
using UnityEngine;
using YG;

namespace Initializers
{
    public class YandexSdkInitializer : InitializerBase
    {
        public YandexSdkInitializer(InitializerBase[] initializers = null) 
            : base(initializers) { }

        public override void Init() 
            => WaitLoad();

        private async void WaitLoad()
        {
            while (!YandexGame.SDKEnabled)
                Debug.Log("Await");

            var curUnScaledTime = Time.unscaledTime;
            var dif = 0.51f - curUnScaledTime;

            if (curUnScaledTime >= 0)
                await Task.Delay((int)(1000 * dif));
            
            Debug.Log("-||- YandexSdkInitializer");
            OnParentInit?.Invoke();
        }
    }
}