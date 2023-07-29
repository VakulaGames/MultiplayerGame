using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        PhotonNetwork.Instantiate(_playerPrefab.name, spawnPosition, Quaternion.identity);
    }
}
