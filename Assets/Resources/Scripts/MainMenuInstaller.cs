using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private SceneChangerTrigger[] _sceneChangerTriggers;
    [SerializeField] private GameModeChanger[] _gameModeChangers;
    public override void InstallBindings()
    { }
    

    public void Initialize()
    {
        foreach (var sceneChanger in _sceneChangerTriggers)
            Container.Inject(sceneChanger); 
        
        foreach (var gameModeChanger in _gameModeChangers)
            Container.Inject(gameModeChanger);    
    }
}
