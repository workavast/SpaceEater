using System;
using Zenject;

namespace SourceCode.Audio
{
    public class AudioManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var audioManager = FindObjectOfType<AudioManager>();
            if (audioManager == null)
                throw new NullReferenceException($"audio manager is null");

            Container.BindInstance(audioManager).AsSingle();
        }
    }
}