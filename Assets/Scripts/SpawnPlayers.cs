using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefabs;
    [SerializeField] private List<GameObject> spawner;
    [SerializeField] private List<GameObject> player_Ui;

    private int id = 0;
    
    private void Start()
    {
        var spawnPos = new Vector3();
        SetRoleID();
            
        switch (id)
        {
            case 0 : spawnPos = spawner[0].transform.localPosition; player_Ui[0].SetActive(true); break;
            case 1 : spawnPos = spawner[1].transform.localPosition; player_Ui[1].SetActive(true); break;
            case 2 : spawnPos = spawner[2].transform.localPosition; player_Ui[2].SetActive(true); break;
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
