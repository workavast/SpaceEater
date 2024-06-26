﻿using SourceCode.Core.GlobalData;
using UnityEngine;
using UnityEngine.Audio;

namespace SourceCode.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        
        public AudioVolumeChanger Volume { get; private set; }

        private PauseableAudioSource[] _pauseableAudioSources;

        private void Awake()
        {
            Volume = new AudioVolumeChanger(mixer, PlayerGlobalData.Instance.VolumeSettings);
            _pauseableAudioSources = GetComponentsInChildren<PauseableAudioSource>();
        }
        
        private void Start()
        {
            Volume.StartInit();
        }

        public void ChangeAudioState(bool pausedAudio)
        {
            foreach (var audioSource in _pauseableAudioSources)
                audioSource.ChangeAudioState(pausedAudio);
        }
    }
}