using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    [SerializeField] private TMP_Text timeTextField;
    [SerializeField] private TMP_Text finalScoreTextField;
    
    private int score;
    private float time;

    private void Start()
    {
        GetData();

        timeTextField.text = "Time : " + time + " sec.";
        // textField.text = "Score : " + score;
        // finalScoreTextField.text = "Final Score : " + (score - Mathf.Round(time / 100));
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void GetData()
    {
        score = ScoreSender.scoreToBeSend;
        time = ScoreSender.timeToBeSend;
    }

    public void BackToMenu()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
