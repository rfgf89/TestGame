using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private PlayerService _playerService;
    [SerializeField] private SceneChanger _sceneChanger;
    public override void InstallBindings()
    {
        BindSelf();
        BindSceneChanger();
        BindPlayerService();
    }

    private void BindSelf()
    {
        Container
            .BindInterfacesTo<BootstrapInstaller>()
            .FromInstance(this)
            .AsSingle();
    }

    private void BindSceneChanger()
    {
        Container
            .Bind<SceneChanger>()
            .FromInstance(_sceneChanger)
            .AsSingle();
    }

    private void BindPlayerService()
    {
        Container
            .Bind<IPlayerService>()
            .To<PlayerService>()
            .FromInstance(Instantiate(_playerService))
            .AsSingle();
    }

    public void Initialize()
    {
        var sceneChanger = Container.Resolve<SceneChanger>();
        Container.Inject(sceneChanger);
    }
}
