using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class LevelInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private SceneChangerTrigger[] _sceneChangerTriggers;
        [SerializeField] private GameModeChanger[] _gameModeChangers;
        [SerializeField] private BoxDestroySpawner[] _boxDestroySpawners;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private MoveToPlayer _moveToPlayer;
        [SerializeField] private PlayerGetYouTime _youTime;
        [SerializeField] private PlayerGetLastTime _lastTime;
        [SerializeField] private PlayerSetLastTime _setLastTime;
        [SerializeField] private PlayerGetLife _getLife;
        public override void InstallBindings()
        {
            BindPlayer();
        }

        private void BindPlayer()
        {
            Container
                .Bind<PlayerController>()
                .FromInstance(_playerController)
                .AsSingle();
        }


        public void Initialize()
        {
           
            
            foreach (var sceneChanger in _sceneChangerTriggers)
                Container.Inject(sceneChanger); 
        
            foreach (var gameModeChanger in _gameModeChangers)
                Container.Inject(gameModeChanger);  
            
            foreach (var boxDestroy in _boxDestroySpawners)
                Container.Inject(boxDestroy);   
            
            Container.Inject(_moveToPlayer);
            Container.Inject(_youTime);
            Container.Inject(_lastTime);
            Container.Inject(_setLastTime);
            Container.Inject(_getLife);
        }
    }

}