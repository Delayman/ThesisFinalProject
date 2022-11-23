using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TestReloadScene : MonoBehaviourPunCallbacks
{
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.U) && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.DestroyAll();
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.CurrentRoom.IsOpen = false;

            PhotonNetwork.AutomaticallySyncScene = false;
            PhotonNetwork.LeaveRoom();
        }
    }
    
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Scenes/Lobby");
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
