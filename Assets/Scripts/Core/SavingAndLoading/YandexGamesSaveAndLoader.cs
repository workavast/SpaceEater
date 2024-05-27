using SourceCode.Core.GlobalData;
using UnityEngine;
using YG;

namespace SourceCode.Core.SavingAndLoading
{
    public class YandexGamesSaveAndLoader : ISaveAndLoader
    {
        public PlayerGlobalDataSave LoadData(out bool isFirstSession)
        {
            isFirstSession = YandexGame.savesData.isFirstSession;
            if (isFirstSession)
            {
                YandexGame.savesData.isFirstSession = false;
                
                Debug.Log("-||- First load data");
                return new PlayerGlobalDataSave();
            }
            
            Debug.Log("-||- Not first load data");
            var save = YandexGame.savesData.playerGlobalDataSave;
            return save;
        }
        
        public void Save(PlayerGlobalData playerGlobalData)
        {
            Debug.Log("-||- Save Data");

            var save = new PlayerGlobalDataSave(playerGlobalData.VolumeSettings, playerGlobalData.LocalizationSettings);
            
            YandexGame.savesData.playerGlobalDataSave = save;
            YandexGame.SaveProgress();
        }
        
        public void ResetSaves()
        {
            Debug.Log("-||- Reset saves");
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
        }
    }
}