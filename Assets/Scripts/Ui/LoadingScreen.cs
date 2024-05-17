using System;
using UnityEngine;

namespace SourceCode.Ui
{
    public class LoadingScreen : MonoBehaviour
    {
        public static LoadingScreen Instance;

        public bool IsShow { get; private set; }
        
        public event Action FadeAnimationEnded;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            IsShow = gameObject.activeSelf;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void StartLoading()
        {
            gameObject.SetActive(true);
            IsShow = true;
        }

        public void EndLoading()
        {
            IsShow = false;
            gameObject.SetActive(false);
            
            FadeAnimationEnded?.Invoke();
        }
    }
}