using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class PlayerGetLife : MonoBehaviour
{
    private IPlayerService _playerService;
    [SerializeField]private TextMeshProUGUI _textMeshProUGUI;
    [Inject]
    private void Construct(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    private void Update()
    {
        _textMeshProUGUI.text = _playerService.playerData.life.ToString();
    }
}
