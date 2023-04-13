using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    private GameObject _playerPrefabs;
    [SerializeField] private GameObject _RunnerA;
    [SerializeField] private GameObject _RunnerB;
    [SerializeField] private GameObject _Watcher;
    [SerializeField] private List<GameObject> spawner;
    [SerializeField] private List<GameObject> player_Ui;

    private int id = 0;
    
    private void Start()
    {
        var spawnPos = new Vector3();
        SetRoleID();
            
        switch (id)
        {
            case 0 : spawnPos = spawner[0].transform.localPosition; player_Ui[0].SetActive(true); _playerPrefabs = _Watcher; break;
            case 1 : spawnPos = spawner[1].transform.localPosition; player_Ui[1].SetActive(true); _playerPrefabs = _RunnerA; break;
            case 2 : spawnPos = spawner[2].transform.localPosition; player_Ui[2].SetActive(true); _playerPrefabs = _RunnerB; break;
            // default: Debug.Log("Role out of bound"); break;
            }

        if (PhotonNetwork.LocalPlayer.IsLocal)
            PhotonNetwork.Instantiate(_playerPrefabs.name, spawnPos, Quaternion.identity);
    }

    private void SetRoleID()
    {
        id = SavedRole.savedRoleID;
    }
}
