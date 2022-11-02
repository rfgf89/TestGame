using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameModeChanger : MonoBehaviour
{
    [SerializeField] private GameMode _gameMode;
    private IPlayerService _playerService;
    
    [Inject]
    private void Construct(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void ChangeGameMode()
    {
        _playerService.playerData.gameMode = _gameMode;
    }
}
