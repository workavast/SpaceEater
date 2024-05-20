using SourceCode.Core.Ad;
using SourceCode.Core.InputDetectors;
using SourceCode.Core.PlayZone;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.Enemies.Factory;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Entities.StaticEatableObjects.EnvironmentSpawning;
using SourceCode.Entities.StaticEatableObjects.Factory;
using SourceCode.Ui.UiSystem;
using SourceCode.Ui.UiSystem.Screens.Gameplay;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class GameplaySceneContext
    {
        public readonly BlackHoleBehaviour BlackHoleBehaviour;
        public readonly SceneLoader SceneLoader;
        public readonly UI_Controller UIController;
        public readonly PlayerController PlayerController;
        public readonly StaticEatableObjectsRepository StaticEatableObjectsRepository;
        public readonly StaticEatableObjectsUpdater StaticEatableObjectsUpdater;
        public readonly EnemiesRepository EnemiesRepository;
        public readonly EnemiesSpawner EnemiesSpawner;
        public readonly EnemiesUpdater EnemiesUpdater;
        public readonly EnvironmentGenerator EnvironmentGenerator;
        public readonly EndGameDetector EndGameDetector;
        public readonly IInputDetector InputDetector;
        public readonly AdController AdController;

        public GameplaySceneContext(
            UI_Controller uiController,
            BlackHoleBehaviour blackHoleBehaviour, 
            EnemiesFactory enemiesFactory,
            StaticEatableObjectsFactory staticEatableObjectsFactory,
            EnemiesSpawnConfig enemiesSpawnConfig, 
            PlayZoneConfig playZoneConfig,
            EnvironmentSpawnConfig environmentSpawnConfig,
            GameEndDetectorConfig gameEndDetectorConfig,
            AdController adController)
        {
            UIController = uiController;
            BlackHoleBehaviour = blackHoleBehaviour;
            AdController = adController;
            PlayerController = new PlayerController(BlackHoleBehaviour);
            
            StaticEatableObjectsRepository = new StaticEatableObjectsRepository(staticEatableObjectsFactory);
            StaticEatableObjectsUpdater = new StaticEatableObjectsUpdater(StaticEatableObjectsRepository);
            
            EnemiesRepository = new EnemiesRepository(enemiesFactory);
            EnemiesUpdater = new EnemiesUpdater(EnemiesRepository);
            
            EnemiesSpawner = new EnemiesSpawner(enemiesSpawnConfig, enemiesFactory, BlackHoleBehaviour, playZoneConfig);
            EnvironmentGenerator = new EnvironmentGenerator(environmentSpawnConfig, staticEatableObjectsFactory);
            EndGameDetector = new EndGameDetector(gameEndDetectorConfig, BlackHoleBehaviour, EnvironmentGenerator, 
                StaticEatableObjectsRepository);

            var joystick = UI_ScreenRepository.GetScreen<GameplayMainScreen>().Joystick;
            InputDetector = new DesktopInput(joystick);
            SceneLoader = new SceneLoader();
        }
    }
}