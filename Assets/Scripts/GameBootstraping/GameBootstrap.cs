using SourceCode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Initializers
{
    public class GameBootstrap : MonoBehaviour
    {
        [Tooltip("Scene that will be load after initializations")]
        [SerializeField] private int sceneIndex;
        
        private int _inits;
        private SceneLoader _sceneLoader;

        private readonly InitializerBase[] _initializers =
        {
            new YandexSdkInitializer(new InitializerBase[]
                {
                    new PlayerGlobalDataInitializer(new InitializerBase[]
                    {
                        new LocalizationInitializer()
                    }),
                }
            )
        };

        private void Awake()
        {
            _inits = _initializers.Length;
            
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
            _inits -= 1;

            if (_inits <= 0)
                _sceneLoader.LoadScene(sceneIndex);
        }
    }
}