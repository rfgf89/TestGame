using UnityEngine;
using Zenject;

public class MoveToPlayer : MonoBehaviour
{
    private PlayerController _playerController;
    private Vector3 _velocity;
    [Inject]
    private void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }


    private void LateUpdate()
    {
        if(Camera.current!=null)
        if(_playerController!=null)
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
            _playerController.transform.position.x - Camera.current.rect.width / 2,
            transform.position.y,
            _playerController.transform.position.z - Camera.current.rect.height / 2), ref _velocity, 0.1f);
    }
}
