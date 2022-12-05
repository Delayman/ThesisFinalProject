using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    
    private int score;

    private void Start()
    {
        GetScore();

        textField.text = "Score : " + score;
    }

    private void GetScore()
    {
        score = ScoreSender.scoreToBeSend;
    }
}
