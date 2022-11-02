using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneChanger : MonoBehaviour
{
    private IPlayerService _playerService;
    
    [Inject]
    public void Construct(IPlayerService playerService)
    {
        _playerService = playerService;
        _playerService.PlayerLoad();
    }
    
    public void ChangeScene(string scene)
    {
        _playerService.PlayerSave();
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        _playerService.PlayerSave();
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        _playerService.PlayerSave();
    }
}
