using SourceCode.Core.GlobalData.Volume;
using UnityEngine;
using UnityEngine.Audio;

namespace SourceCode.Audio
{
    public class AudioVolumeChanger
    {
        private readonly VolumeSettings _volumeSettings;
        private readonly AudioMixer _mixer;

        private const string EffectsParam = "Effects";
        private const string OstParam = "Music";

        public AudioVolumeChanger(AudioMixer mixer, VolumeSettings volumeSettings)
        {
            _mixer = mixer;
            _volumeSettings = volumeSettings;
        }

        public float MasterVolume => _volumeSettings.MasterVolume;
        public float OstVolume => _volumeSettings.OstVolume;
        public float EffectsVolume => _volumeSettings.EffectsVolume;

        public void StartInit()
        {
            SetVolume(EffectsParam, EffectsVolume);
            SetVolume(OstParam, OstVolume);
        }

        public void SetEffectsVolume(float newVolume)
        {
            _volumeSettings.ChangeEffectsVolume(newVolume);
            SetVolume(EffectsParam, EffectsVolume);
        }

        public void SetOstVolume(float newVolume)
        {
            _volumeSettings.ChangeOstVolume(newVolume);
            SetVolume(OstParam, OstVolume);
        }

        private void SetVolume(string paramName, float newVolume)
            => _mixer.SetFloat($"{paramName}", Mathf.Lerp(-80, 0, Mathf.Sqrt(Mathf.Sqrt(newVolume))));
    }
}