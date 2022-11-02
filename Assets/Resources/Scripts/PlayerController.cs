using System.Security.Principal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedUp;
    [SerializeField] private float speedRight;
    [SerializeField] private float gravitySpeed;
    [SerializeField] private InputAction _move;
    [SerializeField] private UnityEvent _loseGameEvent;
    private IPlayerService _playerService;
    [Inject]
    private void Construct(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    private void Start()
    {
        _move.Enable();
        _playerService.StartPlay();
    }
    
    private void Update()
    {
        if (_move.ReadValue<float>() == 1.0f) 
            transform.position += (Vector3.up * speedUp + Vector3.right * speedRight * _playerService.playerData.speedModify) * Time.deltaTime;
        else
            transform.position += Vector3.down * gravitySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _playerService.EndPlay();
        _loseGameEvent?.Invoke();
        Destroy(gameObject);
    }
}
