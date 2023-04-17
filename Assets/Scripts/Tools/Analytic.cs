using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;

public class Analytic : MonoBehaviour
{
    private TimerManager timerManager;
    private VoiceAnalyticLogger voiceLogger;
    
    // private List<FPS_PlayerMovement> vcGetterList = new List<FPS_PlayerMovement>();
    
    //Here!
    public float timerP1, timerP2, timerP3, timerP4, timerP5, timerP6, finalTimer;
    public float voiceChatTimerWatcher, voiceChatTimerRunnerA, voiceChatTimerRunnerB;
    public float voiceChatUsageWatcher, voiceChatUsageRunnerA, voiceChatUsageRunnerB;

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
        voiceLogger = FindObjectOfType<VoiceAnalyticLogger>();
    }

    private void Update()
    {
        // if (vcGetterList.Count != 3) return;
            
        voiceChatTimerWatcher = Mathf.Round(voiceLogger.VCTimerP1);
        voiceChatTimerRunnerA = Mathf.Round(voiceLogger.VCTimerP2);
        voiceChatTimerRunnerB = Mathf.Round(voiceLogger.VCTimerP3);

        voiceChatUsageWatcher = voiceLogger.VCUseageP1;
        voiceChatUsageRunnerA = voiceLogger.VCUseageP2;
        voiceChatUsageRunnerB = voiceLogger.VCUseageP3;
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

        roomName = SavedRole.roomName;
    }
    
    //for sending data testing ONLY

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
