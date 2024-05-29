using Initializers.Initializing;
using SourceCode.Core;
using UnityEngine;

namespace Initializers
{
    public class GameBootstrap : MonoBehaviour
    {
        [Tooltip("Scene that will be load after initializations")]
        [SerializeField] private int sceneIndex;

#if PLATFORM_WEBGL
        private readonly IGameInitializersBuilder _gameInitializersBuilder = new YandexGamesGameInitializersBuilder();
#elif PLATFORM_ANDROID
        private readonly IGameInitializersBuilder _gameInitializersBuilder = new AndroidGameInitializersBuilder();
#endif
        private int _initsCounter;
        private SceneLoader _sceneLoader;
        private InitializerBase[] _initializers;
        
        private void Awake()
        {
            _initializers = _gameInitializersBuilder.GetInitializers(this);
            _initsCounter = _initializers.Length;
            foreach (var initializer in _initializers)
                initializer.OnInit += UpdateInits;
        }

        private void Start()
        {
            _sceneLoader = new SceneLoader();
            _sceneLoader.Init();
            foreach (var initializer in _initializers)
                initializer.Init();
        }

        private void UpdateInits()
        {
            _initsCounter -= 1;

            if (_initsCounter <= 0)
                _sceneLoader.LoadScene(sceneIndex);
        }
    }
}