using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DataPoster : MonoBehaviour
{
    private void Start()
    {
        var _data = FindObjectOfType<Analytic>();
        
        var roomName = Analytics.CustomEvent(
            "RoomName",
            new Dictionary<string, object>
            {
                {"Room_Name", _data.roomName},
            });
        
        var timeResult = Analytics.CustomEvent(
            "PuzzleTimer",
            new Dictionary<string, object>
            {
                {"Puzzle_A", _data.timerP1},
                {"Puzzle_B", _data.timerP2},
                {"Puzzle_C", _data.timerP3},
                {"Puzzle_D", _data.timerP4},
                {"Puzzle_E", _data.timerP5},
                {"Puzzle_F", _data.timerP6},
                {"Final_Time", _data.finalTimer}
            });

        var vcTimerResult = Analytics.CustomEvent(
            "VoiceChatTimer",
            new Dictionary<string, object>
            {
                {"Watcher_VC_Timer", _data.voiceChatTimerWatcher},
                {"Runner_A_VC_Timer", _data.voiceChatTimerRunnerA},
                {"Runner_B_VC_Timer", _data.voiceChatTimerRunnerB},
            });
        
        var vcUsageResult = Analytics.CustomEvent(
            "VoiceChatUsage",
            new Dictionary<string, object>
            {
                {"Watcher_VC_Usage", _data.voiceChatUsageWatcher},
                {"Runner_A_VC_Usage", _data.voiceChatUsageRunnerA},
                {"Runner_B_VC_Usage", _data.voiceChatUsageRunnerB},
            });
        
        Debug.Log($"Room name Result : {roomName} + {_data.roomName}");
        Debug.Log($"Total time Result : {timeResult} + {_data.finalTimer}");
        Debug.Log($"VC time Result : {vcTimerResult} + P1 :{_data.voiceChatTimerWatcher} + P2 :{_data.voiceChatTimerRunnerA} + P3 :{_data.voiceChatTimerRunnerB}");
        Debug.Log($"VC usage Result : {vcUsageResult} + P1 : {_data.voiceChatUsageWatcher} + P2 : {_data.voiceChatUsageRunnerA} + P3 : {_data.voiceChatUsageRunnerB}");

        //For dummies testing ONLY

    //     var _data = FindObjectOfType<Analytic>();
    //     var result = Analytics.CustomEvent(
    //         "PuzzleTimer",
    //         new Dictionary<string, object>
    //         {
    //             {"PuzzleA", _data.timerTP1},
    //             {"PuzzleB", _data.timerTP2},
    //             {"PuzzleC", _data.timerTP3},
    //             {"PuzzleD", _data.timerTP4},
    //             {"PuzzleE", _data.timerTP5},
    //             {"PuzzleF", _data.timerTP6},
    //             {"FinalTime", _data.finalTTimer}
    //         });
    //     
    //     Debug.Log($"Analytic Result : {result} + {_data.finalTTimer}");
    //     
    //     var resultB = Analytics.CustomEvent(
    //                 "PuzzleTimerChecker",
    //                 new Dictionary<string, object>
    //                 {
    //                     {"PuzzleA", _data.timerTP1},
    //                     {"PuzzleB", _data.timerTP2},
    //                     {"PuzzleC", _data.timerTP3},
    //                     {"PuzzleD", _data.timerTP4},
    //                     {"PuzzleE", _data.timerTP5},
    //                     {"PuzzleF", _data.timerTP6},
    //                     {"FinalTime", _data.finalTTimer}
    //                 });
    //             
    //             Debug.Log($"Analytic Result : {resultB} + {_data.timerTP6}");
    }
}
