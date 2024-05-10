using System;
using SourceCode.Core.GlobalData;
using SourceCode.Core.GlobalData.Localization;
using SourceCode.Core.GlobalData.Volume;
using UnityEngine;
using YG;

namespace Settings
{
    public class PlayerGlobalData
    {
        private static PlayerGlobalData _instance;
        public static PlayerGlobalData Instance => _instance ??= new PlayerGlobalData();

        public readonly VolumeSettings VolumeSettings = new();
        public readonly LocalizationSettings LocalizationSettings = new();
     
        public bool IsFirstSession { get; private set; }
        
        public event Action OnInit;

        public void Initialize()
        {
            YandexGame.GetDataEvent += GetData;
            YandexGame.GetDataEvent += SubsAfterFirstLoad;

            Debug.Log("-||- load start");
            YandexGame.LoadProgress();
        }

        public static void ResetSaves()
        {
            Debug.Log("-||- Reset saves");
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
        }
        
        private void GetData()
        {
            IsFirstSession = YandexGame.savesData.isFirstSession;
            if (IsFirstSession)
            {
                YandexGame.savesData.isFirstSession = false;
                
                SaveData();
                Debug.Log("-||- First get data");
                //default values in settings is a default save values, so we can just return
                return;
            }
            
            Debug.Log("-||- Not first get data");
            var save = YandexGame.savesData.playerGlobalDataSave;
            VolumeSettings.LoadData(save.volumeSettingsSave);
            LocalizationSettings.SetData(save.localizationSettingsSave);
        }
        
        private void SaveData()
        {
            Debug.Log("-||- SaveData");

            var save = new PlayerGlobalDataSave(VolumeSettings, LocalizationSettings);
            
            YandexGame.savesData.playerGlobalDataSave = save;
            YandexGame.SaveProgress();
        }
        
        private void SubsAfterFirstLoad()
        {
            Debug.Log("-||- SubsAfterFirstLoad");
            
            YandexGame.GetDataEvent -= SubsAfterFirstLoad;

            ISettings[] settings =
            {
                VolumeSettings, 
                LocalizationSettings
            };
            foreach (var setting in settings)
                setting.OnChange += SaveData;
            
            YandexGame.GetDataEvent -= SubsAfterFirstLoad;
            
            OnInit?.Invoke();
        }
    }
}
