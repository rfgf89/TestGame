using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class PlayerGetYouTime : MonoBehaviour
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
        _textMeshProUGUI.text = math.floor(_playerService.playerData.currentTime/60) + "." + math.floor(_playerService.playerData.currentTime%60);
    }
}
