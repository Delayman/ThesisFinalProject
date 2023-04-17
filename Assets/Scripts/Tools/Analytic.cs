using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;

public class Analytic : MonoBehaviour
{
    private TimerManager timerManager;
    private List<FPS_PlayerMovement> vcGetterList = new List<FPS_PlayerMovement>();

    public float timerP1, timerP2, timerP3, timerP4, timerP5, timerP6, finalTimer;
    public float voiceChatTimerWatcher, voiceChatTimerRunnerA, voiceChatTimerRunnerB;
    public int voiceChatUsageWatcher, voiceChatUsageRunnerA, voiceChatUsageRunnerB;

    public string roomName;
    
    // public float timerTP1;
    // public float timerTP2;
    // public float timerTP3;
    // public float timerTP4;
    // public float timerTP5;
    // public float timerTP6;
    // public float finalTTimer;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // TestSendData();
    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
    }

    private void FixedUpdate()
    {
        if (vcGetterList.Count != 3)
        {
            vcGetterList = FindObjectsOfType<FPS_PlayerMovement>().ToList();
        }
            
        timerP1 = timerManager.finpTimer1;
        timerP2 = timerManager.finpTimer2;
        timerP3 = timerManager.finpTimer3;
        timerP4 = timerManager.finpTimer4;
        timerP5 = timerManager.finpTimer5;
        timerP6 = timerManager.finpTimer6;

        finalTimer = Mathf.Round(ScoreManager.totalTime);

        roomName = SavedRole.roomName;
        
        if (vcGetterList.Count != 3) return;
            
        voiceChatTimerWatcher = Mathf.Round(vcGetterList[0].VCTimer);
        voiceChatTimerRunnerA = Mathf.Round(vcGetterList[1].VCTimer);
        voiceChatTimerRunnerB = Mathf.Round(vcGetterList[2].VCTimer);
        
        voiceChatUsageWatcher = vcGetterList[0].VCUsage;
        voiceChatUsageRunnerA = vcGetterList[1].VCUsage;
        voiceChatUsageRunnerB = vcGetterList[2].VCUsage;

        //for sending data testing ONLY
    }

    // private void TestSendData()
    // {
    //     timerTP1 = 10;
    //     timerTP2 = 2;
    //     timerTP3 = 88;
    //     timerTP4 = 15;
    //     timerTP5 = 23;
    //     timerTP6 = 69;
    //     finalTTimer = 420;
    //
    // }
}
