using System;
using SourceCode.Core.GlobalData.Localization;
using SourceCode.Core.GlobalData.Volume;
using SourceCode.Core.SavingAndLoading;
using UnityEngine;

namespace SourceCode.Core.GlobalData
{
    public class PlayerGlobalData
    {
        private static PlayerGlobalData _instance;
        public static PlayerGlobalData Instance => _instance ??= new PlayerGlobalData();

        public readonly VolumeSettings VolumeSettings = new();
        public readonly LocalizationSettings LocalizationSettings = new();
     
        public bool IsFirstSession { get; private set; }

        private ISaveAndLoader _saveAndLoader;
        
        public event Action OnInit;

        public void Initialize()
        {
            Debug.Log("-||- PlayerGlobalData initializing");

#if PLATFORM_WEBGL
            _saveAndLoader = new YandexGamesSaveAndLoader();
#endif
            
            LoadData();
            SubsAfterFirstLoad();
        }
        
        public void ResetSaves() 
            => _saveAndLoader.ResetSaves();
        
        private void LoadData()
        {
            var save = _saveAndLoader.LoadData(out var isFirstSession);
            
            IsFirstSession = isFirstSession;
            VolumeSettings.LoadData(save.volumeSettingsSave);
            LocalizationSettings.SetData(save.localizationSettingsSave);
        }
        
        private void SaveData() 
            => _saveAndLoader.Save(this);

        private void SubsAfterFirstLoad()
        {
            Debug.Log("-||- SubsAfterFirstLoad");
            
            ISettings[] settings =
            {
                VolumeSettings, 
                LocalizationSettings
            };
            foreach (var setting in settings)
                setting.OnChange += SaveData;
            
            OnInit?.Invoke();
        }
    }
}
