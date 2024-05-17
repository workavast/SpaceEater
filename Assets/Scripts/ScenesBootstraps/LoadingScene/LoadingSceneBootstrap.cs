using UnityEngine;

namespace SourceCode.ScenesBootstraps.LoadingScene
{
    public class LoadingSceneBootstrap : MonoBehaviour
    {
        private SceneLoader _sceneLoader;
        
        private void Start()
        {
            _sceneLoader = new SceneLoader();
            _sceneLoader.Init();
        }
    }
}