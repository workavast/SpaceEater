using UnityEngine;

namespace SourceCode.Ui.UiSystem.Screens
{
    public class LoadingScreen : MonoBehaviour
    {
        public static LoadingScreen Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void StartLoading()
        {
            gameObject.SetActive(true);
        }

        public void EndLoading()
        {
            gameObject.SetActive(false);
        }
    }
}