using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class GeneratorTimer : MonoBehaviour
{
    public float currentPower = 100;

    [SerializeField] private float maxPower = 100;
    [SerializeField] private TMP_Text powerTutorialTxt;

    [Tooltip("Set how fast the power will drain (1 is normal speed")]
    [Range(0.1f, 5f)][SerializeField] private float drainSpeed = 1;
    
    public bool isOutOfPower;
    public bool isTutorialScene;
    
    private bool isloadScene;

    private void Start()
    {
        currentPower = maxPower;
    }

    private void FixedUpdate()
    {
        if(!isOutOfPower) 
            CountDown();

        if (isOutOfPower && !isloadScene && !isTutorialScene)
        {
            LoadResultScene();
            isloadScene = true;
        }

        if (currentPower > maxPower)
        {
            currentPower = maxPower;
        }
        
        powerTutorialTxt.text = Mathf.Round(currentPower) + " %";
    }

    private void LoadResultScene()
    {
        PhotonNetwork.LoadLevel("Scenes/Result");
    }

    private void CountDown()
    {
        currentPower -= Time.deltaTime * drainSpeed;

        if (currentPower <= 0)
            isOutOfPower = true;
    }
    
    public void AddTime(float _time)
    {
        currentPower += _time;
    }
}
