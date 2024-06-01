using SourceCode.Ad.AdControllers;
using SourceCode.Ad.Preparing;
using SourceCode.Core;
using SourceCode.Entities.BlackHole;
using SourceCode.Entities.BlackHole.BlackHoleUpdating;
using SourceCode.Entities.Enemies;
using SourceCode.Entities.Enemies.Repository;
using SourceCode.Entities.Enemies.Spawning;
using SourceCode.Entities.StaticEatableObjects;
using SourceCode.Entities.StaticEatableObjects.EnvironmentGeneration;
using SourceCode.Entities.StaticEatableObjects.StaticEatableObjectsBySizeRemoving;
using SourceCode.ReviewRequest;
using SourceCode.ScenesBootstraps.GameplayScene.EndGameDetection;
using SourceCode.Ui.UiSystem;

namespace SourceCode.ScenesBootstraps.GameplayScene.Context
{
    public class GameplaySceneContext
    {
        public readonly BlackHoleBehaviour BlackHoleBehaviour;
        public readonly SceneLoader SceneLoader;
        public readonly UI_Controller UIController;
        public readonly IBlackHoleUpdater BlackHoleUpdater;
        public readonly IStaticEatableObjectsRepository StaticEatableObjectsRepository;
        public readonly IStaticEatableObjectsUpdater StaticEatableObjectsUpdater;
        public readonly IEnemiesRepository EnemiesRepository;
        public readonly IEnemiesSpawner EnemiesSpawner;
        public readonly IEnemiesUpdater EnemiesUpdater;
        public readonly IEnvironmentGenerator EnvironmentGenerator;
        public readonly EndGameDetector EndGameDetector;
        public readonly IAdPreparedTrigger AdPreparedTrigger;
        public readonly IAdTriggerActivator AdTriggerActivator;
        public readonly IAdPreparingTimer AdPreparingTimer;
        public readonly IStaticEatableObjectsBySizeRemover StaticEatableObjectsBySizeRemover;
        public readonly IReviewRequester ReviewRequester;
        public readonly IFullScreenAd FullScreenAd;

        private GameplaySceneContext(
            UI_Controller uiController,
            EndGameDetector endGameDetector, 
            BlackHoleBehaviour blackHoleBehaviour, 
            IBlackHoleUpdater blackHoleUpdater,
            IEnemiesRepository enemiesRepository,
            IEnemiesUpdater enemiesUpdater,
            IEnemiesSpawner enemiesSpawner,
            IStaticEatableObjectsRepository staticEatableObjectsRepository,
            IStaticEatableObjectsUpdater staticEatableObjectsUpdater,
            IStaticEatableObjectsBySizeRemover staticEatableObjectsBySizeRemover, 
            IEnvironmentGenerator environmentGenerator,
            IAdPreparedTrigger adPreparedTrigger,
            IAdTriggerActivator adTriggerActivator, 
            IAdPreparingTimer adPreparingTimer,
            IReviewRequester reviewRequester,
            IFullScreenAd fullScreenAd)
        {
            UIController = uiController;
            EndGameDetector = endGameDetector;
            BlackHoleBehaviour = blackHoleBehaviour;
            BlackHoleUpdater = blackHoleUpdater;
            
            EnemiesRepository = enemiesRepository;
            EnemiesUpdater = enemiesUpdater;
            EnemiesSpawner = enemiesSpawner;

            StaticEatableObjectsRepository = staticEatableObjectsRepository;
            StaticEatableObjectsUpdater = staticEatableObjectsUpdater;
            StaticEatableObjectsBySizeRemover = staticEatableObjectsBySizeRemover;
            EnvironmentGenerator = environmentGenerator;

            AdPreparedTrigger = adPreparedTrigger;
            AdTriggerActivator = adTriggerActivator;
            AdPreparingTimer = adPreparingTimer;
            
            ReviewRequester = reviewRequester;
            FullScreenAd = fullScreenAd;

            SceneLoader = new SceneLoader();
        }
    }
}