﻿using System;

namespace SourceCode.Core.GlobalData.Volume
{
    public sealed class VolumeSettings : ISettings
    {
        public float OstVolume { get; private set; }
        public float EffectsVolume { get; private set; }
        
        public event Action OnChange;

        public VolumeSettings()
        {
            OstVolume = 0.5f;
            EffectsVolume = 0.5f;
        }
    
        public void ChangeOstVolume(float newVolume)
        {
            OstVolume = newVolume;
            OnChange?.Invoke();
        }
    
        public void ChangeEffectsVolume(float newVolume)
        {
            EffectsVolume = newVolume;
            OnChange?.Invoke();
        }
        
        public void LoadData(VolumeSettingsSave volumeSettings)
        {
            OstVolume = volumeSettings.OstVolume;
            EffectsVolume = volumeSettings.EffectsVolume;
        }
    }
}