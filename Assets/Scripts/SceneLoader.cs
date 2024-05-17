using System;
using SourceCode.Ui;
using UnityEngine.SceneManagement;

namespace SourceCode
{
    public class SceneLoader
    {
        public const int GAME_BOOTSTRAP_SCENE_INDEX = 0;
        public const int LOAD_SCENE_INDEX = 3;
        
        private static int _targetSceneIndex = -1;

        public event Action LoadingStarted;
        
        public void Init()
        {
            var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (activeSceneIndex != GAME_BOOTSTRAP_SCENE_INDEX && _targetSceneIndex <= -1)
            {
                LoadingScreen.Instance.EndLoading();
                return;
            }
            
            if (activeSceneIndex == LOAD_SCENE_INDEX)
                LoadTargetScene();
            
            if(activeSceneIndex == _targetSceneIndex)
                LoadingScreen.Instance.EndLoading();
        }
        
        public void LoadScene(int index)
        {
            _targetSceneIndex = index;
            
            LoadingStarted?.Invoke();
            
            LoadingScreen.Instance.StartLoading();
            SceneManager.LoadSceneAsync("Scenes/LoadScene");
        }

        private void LoadTargetScene()
        {
            SceneManager.LoadSceneAsync(_targetSceneIndex);
        }
    }
}