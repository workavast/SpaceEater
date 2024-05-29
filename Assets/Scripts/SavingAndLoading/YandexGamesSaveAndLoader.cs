using SourceCode.Core.GlobalData;
using UnityEngine;
using YG;

namespace SourceCode.SavingAndLoading
{
    public class YandexGamesSaveAndLoader : ISaveAndLoader
    {
        public PlayerGlobalDataSave Load(out bool isFirstSession)
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
            var save = new PlayerGlobalDataSave(playerGlobalData);
            YandexGame.savesData.playerGlobalDataSave = save;
            YandexGame.SaveProgress();
        }
        
        public void ResetSave()
        {
            Debug.Log("-||- Reset saves");
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
        }
    }
}