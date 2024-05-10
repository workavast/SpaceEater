using System;
using SourceCode.Core.GlobalData.Localization;
using SourceCode.Core.GlobalData.Volume;

namespace SourceCode.Core.GlobalData
{
    [Serializable]
    public class PlayerGlobalDataSave
    {
        public VolumeSettingsSave volumeSettingsSave;
        public LocalizationSettingsSave localizationSettingsSave;

        public PlayerGlobalDataSave()
        {
            volumeSettingsSave = new();
            localizationSettingsSave = new();
        }
        
        public PlayerGlobalDataSave(
            VolumeSettings volumeSettings,
            LocalizationSettings localizationSettings)
        {
            volumeSettingsSave = new VolumeSettingsSave(volumeSettings);
            localizationSettingsSave = new LocalizationSettingsSave(localizationSettings);
        }
    }
}