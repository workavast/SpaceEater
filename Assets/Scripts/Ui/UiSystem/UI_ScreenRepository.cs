using System;
using System.Collections.Generic;
using System.Linq;
using SourceCode.Ui.UiSystem.Screens;
using UnityEngine;

namespace SourceCode.Ui.UiSystem
{
    public class UI_ScreenRepository : MonoBehaviour
    {
        private Dictionary<Type, UI_ScreenBase> _screens;

        private static UI_ScreenRepository _instance;
        
        public static IReadOnlyList<UI_ScreenBase> Screens => _instance._screens.Values.ToArray();

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = this;

            _screens = new Dictionary<Type, UI_ScreenBase>();

            UI_ScreenBase[] uiScreens = FindObjectsOfType<UI_ScreenBase>(true);
            foreach (UI_ScreenBase screen in uiScreens) 
                _screens.Add(screen.GetType(), screen);
        }

        public static TScreen GetScreen<TScreen>() where TScreen : UI_ScreenBase
        {
            if (_instance == null) 
                throw new NullReferenceException($"Instance is null");

            if (!_instance._screens.TryGetValue(typeof(TScreen), out UI_ScreenBase screen))
            {
                Debug.LogWarning($"Error: invalid parameter: {typeof(TScreen)}");
                return default;
            }

            return (TScreen)screen;
        }
    }
}