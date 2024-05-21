using System;
using SourceCode.Ui.AnimationBlocks;
using UnityEngine;

namespace SourceCode.Ui
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private AnimationFadeBlock animationFadeBlock;
        
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
            animationFadeBlock.Show(null);
            IsShow = true;
        }

        public void EndLoading()
        {
            animationFadeBlock.Hide(() =>
            {
                IsShow = false;
                gameObject.SetActive(false);
                FadeAnimationEnded?.Invoke();
            });
        }
    }
}