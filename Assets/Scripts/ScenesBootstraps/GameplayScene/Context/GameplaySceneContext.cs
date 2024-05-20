using SourceCode.Core.Ad;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Entities.StaticEatableObjects.EnvironmentGeneration;
using SourceCode.ScenesBootstraps.GameplayScene.EndGameDetection;
using SourceCode.Ui.UiSystem;

namespace SourceCode.ScenesBootstraps.GameplayScene.Context
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
        public readonly AdController AdController;

        private GameplaySceneContext(
            UI_Controller uiController,
            BlackHoleBehaviour blackHoleBehaviour, 
            AdController adController,
            EnemiesRepository enemiesRepository,
            EnemiesUpdater enemiesUpdater,
            EnemiesSpawner enemiesSpawner,
            StaticEatableObjectsRepository staticEatableObjectsRepository,
            StaticEatableObjectsUpdater staticEatableObjectsUpdater,
            PlayerController playerController,
            EnvironmentGenerator environmentGenerator,
            EndGameDetector endGameDetector)
        {
            UIController = uiController;
            AdController = adController;
            BlackHoleBehaviour = blackHoleBehaviour;
            PlayerController = playerController;
            
            StaticEatableObjectsRepository = staticEatableObjectsRepository;
            StaticEatableObjectsUpdater = staticEatableObjectsUpdater;

            EnemiesRepository = enemiesRepository;
            EnemiesUpdater = enemiesUpdater;
            EnemiesSpawner = enemiesSpawner;

            EnvironmentGenerator = environmentGenerator;
            EndGameDetector = endGameDetector;

            SceneLoader = new SceneLoader();
        }
    }
}