using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class BoxDestroySpawner : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField]private Transform _camera;
    [SerializeField]private float distanceSpawn;
    [SerializeField]private Vector3 prevPlayerDistance = Vector3.zero;
    [SerializeField] private GameObject _prefub;
    [SerializeField] private float randomHeight;
    private Vector3 offsetCamera;
    [Inject]
    private void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }

    private void Start()
    {
        offsetCamera = transform.position - _camera.position;
    }

    private void FixedUpdate()
    {
        if (math.distance(_playerController.transform.position, prevPlayerDistance) > distanceSpawn)
        {
            Instantiate(_prefub, _prefub.transform.localPosition+transform.position + Vector3.up * Random.Range(0f, randomHeight),
                Quaternion.identity, null);
            prevPlayerDistance = _playerController.transform.position;
        }
        transform.position = math.floor(_camera.position/2f)*2f + (float3)offsetCamera;
    }
}
