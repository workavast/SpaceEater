using SourceCode.Core.PlayZone;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.Enemies.Factory;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Entities.StaticEatableObjects.Factory;
using SourceCode.EnvironmentSpawning;
using SourceCode.Ui.UiSystem;

namespace SourceCode.ScenesBootstraps.GameplayScene
{
    public class GameplaySceneContext
    {
        public readonly BlackHoleBehaviour BlackHoleBehaviour;
        public readonly UI_Controller UIController;
        public readonly PlayerController PlayerController;
        public readonly StaticEatableObjectsRepository StaticEatableObjectsRepository;
        public readonly StaticEatableObjectsUpdater StaticEatableObjectsUpdater;
        public readonly EnemiesRepository EnemiesRepository;
        public readonly EnemiesSpawner EnemiesSpawner;
        public readonly EnemiesUpdater EnemiesUpdater;
        public readonly EnvironmentGenerator EnvironmentGenerator;
        public readonly EndGameDetector EndGameDetector;
        
        public GameplaySceneContext(
            UI_Controller uiController,
            BlackHoleBehaviour blackHoleBehaviour, 
            EnemiesFactory enemiesFactory,
            StaticEatableObjectsFactory staticEatableObjectsFactory,
            EnemiesSpawnConfig enemiesSpawnConfig, 
            PlayZoneConfig playZoneConfig,
            EnvironmentSpawnConfig environmentSpawnConfig,
            GameEndDetectorConfig gameEndDetectorConfig)
        {
            UIController = uiController;
            BlackHoleBehaviour = blackHoleBehaviour;
            PlayerController = new PlayerController(BlackHoleBehaviour);
            
            StaticEatableObjectsRepository = new StaticEatableObjectsRepository(staticEatableObjectsFactory);
            StaticEatableObjectsUpdater = new StaticEatableObjectsUpdater(StaticEatableObjectsRepository);
            
            EnemiesRepository = new EnemiesRepository(enemiesFactory);
            EnemiesUpdater = new EnemiesUpdater(EnemiesRepository);
            
            EnemiesSpawner = new EnemiesSpawner(enemiesSpawnConfig, enemiesFactory, BlackHoleBehaviour, playZoneConfig);
            EnvironmentGenerator = new EnvironmentGenerator(environmentSpawnConfig, staticEatableObjectsFactory);
            EndGameDetector = new EndGameDetector(gameEndDetectorConfig, BlackHoleBehaviour, EnvironmentGenerator, 
                StaticEatableObjectsRepository);
        }
    }
}