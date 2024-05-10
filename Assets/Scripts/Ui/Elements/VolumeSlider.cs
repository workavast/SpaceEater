using System;
using SourceCode.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SourceCode.Ui.Elements
{
    [RequireComponent(typeof(Slider))]
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private VolumeType volumeType;

        [Inject] private readonly AudioManager _audioManager;
        
        private Slider _slider;
        
        private event Action<float> OnValueChange;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(ChangeValue);
        }

        private void Start()
        {
            switch (volumeType)
            {
                case VolumeType.Music:
                    _slider.value = _audioManager.Volume.OstVolume;
                    OnValueChange += SetOstVolume;
                    break;
                case VolumeType.Effects:
                    _slider.value = _audioManager.Volume.EffectsVolume;
                    OnValueChange += SetEffectsVolume;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ChangeValue(float newValue) => OnValueChange?.Invoke(newValue);
        
        private void SetEffectsVolume(float newVolume) => _audioManager.Volume.SetEffectsVolume(newVolume);
        
        private void SetOstVolume(float newVolume) => _audioManager.Volume.SetOstVolume(newVolume);

        private void OnDestroy() => _slider.onValueChanged.RemoveListener(ChangeValue);

        private enum VolumeType
        {
            Music = 10,
            Effects = 20
        }
    }
}