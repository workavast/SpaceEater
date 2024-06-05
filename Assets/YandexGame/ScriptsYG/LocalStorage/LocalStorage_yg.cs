using UnityEngine;
using System.Runtime.InteropServices;
using System;

namespace YG
{
    public partial class YandexGame
    {
#if PLATFORM_WEBGL
        [DllImport("__Internal")]
        private static extern void SaveToLocalStorage(string key, string value);

        [DllImport("__Internal")]
        private static extern string LoadFromLocalStorage(string key);

        [DllImport("__Internal")]
        private static extern int HasKeyInLocalStorage(string key);
#endif

        public static bool HasKey(string key)
        {
#if !UNITY_EDITOR && PLATFORM_WEBGL
            try
            {
                return HasKeyInLocalStorage(key) == 1;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
#endif
            return false;
        }

#if PLATFORM_WEBGL
        [DllImport("__Internal")]
        private static extern void RemoveFromLocalStorage(string key);
#endif
        public static void RemoveLocalSaves()
        {
#if !UNITY_EDITOR && PLATFORM_WEBGL
            RemoveFromLocalStorage("savesData");
#endif
        }
    }
}
