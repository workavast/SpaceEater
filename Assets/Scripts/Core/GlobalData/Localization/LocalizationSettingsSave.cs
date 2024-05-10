using System;

namespace SourceCode.Core.GlobalData.Localization
{
    [Serializable]
    public sealed class LocalizationSettingsSave
    {
        public int LocalizationId = 1;
        
        public LocalizationSettingsSave()
        {
            LocalizationId = 1;
        }
        
        public LocalizationSettingsSave(LocalizationSettings settings)
            => LocalizationId = settings.LocalizationId;
    }
}