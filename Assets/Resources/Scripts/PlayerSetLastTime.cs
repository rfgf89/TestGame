using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSetLastTime : MonoBehaviour
{
    private IPlayerService _playerService;
    [Inject]
    public void Construct(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public void SetLastTime()
    {
        _playerService.playerData.timeInLastLife = _playerService.playerData.currentTime;
    }
}
