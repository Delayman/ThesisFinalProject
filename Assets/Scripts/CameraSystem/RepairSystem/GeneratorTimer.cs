using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GeneratorTimer : MonoBehaviour
{
    public float currentPower = 100;

    [SerializeField] private float maxPower = 100;
    [Tooltip("Set how fast the power will drain (1 is normal speed")]
    [Range(0.1f, 5f)][SerializeField] private float drainSpeed = 1;
    
    public bool isOutOfPower;
    private bool isloadScene;

    private void Start()
    {
        currentPower = maxPower;
    }

    private void FixedUpdate()
    {
        if(!isOutOfPower) 
            CountDown();

        if (isOutOfPower && !isloadScene)
        {
            LoadResultScene();
            isloadScene = true;
        }

        if (currentPower > maxPower)
        {
            currentPower = maxPower;
        }
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
