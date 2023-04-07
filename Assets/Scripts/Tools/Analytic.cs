using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Analytic : MonoBehaviour
{
    private TimerManager timerManager;

    public float timerP1, timerP2, timerP3, timerP4, timerP5, timerP6, finalTimer;
    public float timerTP1;
    public float timerTP2;
    public float timerTP3;
    public float timerTP4;
    public float timerTP5;
    public float timerTP6;
    public float finalTTimer;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        TestSendData();
    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
    }

    private void FixedUpdate()
    {
        timerP1 = timerManager.finpTimer1;
        timerP2 = timerManager.finpTimer2;
        timerP3 = timerManager.finpTimer3;
        timerP4 = timerManager.finpTimer4;
        timerP5 = timerManager.finpTimer5;
        timerP6 = timerManager.finpTimer6;

        finalTimer = Mathf.Round(ScoreManager.totalTime);
        
        //for sending data testing ONLY
        
    }

    private void TestSendData()
    {
        timerTP1 = 10;
        timerTP2 = 2;
        timerTP3 = 88;
        timerTP4 = 15;
        timerTP5 = 23;
        timerTP6 = 69;
        finalTTimer = 420;

    }
}
