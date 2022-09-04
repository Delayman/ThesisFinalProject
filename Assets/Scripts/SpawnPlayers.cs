using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefabs;

    [SerializeField] private float _minX, _maxX, _minY, _maxY;

    private void Start()
    {
        Vector2 _randomPos = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
        PhotonNetwork.Instantiate(_playerPrefabs.name, _randomPos, Quaternion.identity);
    }
}
