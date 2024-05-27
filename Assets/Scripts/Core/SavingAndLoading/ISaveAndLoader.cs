using SourceCode.Core.GlobalData;

namespace SourceCode.Core.SavingAndLoading
{
    public interface ISaveAndLoader
    {
        public PlayerGlobalDataSave LoadData(out bool isFirstSession);

        public void Save(PlayerGlobalData playerGlobalData);

        public void ResetSaves();
    }
}