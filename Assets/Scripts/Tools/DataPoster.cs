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
            "PuzzleTimer",
            new Dictionary<string, object>
            {
                {"Room Name", _data.roomName},
            });
        
        var timeResult = Analytics.CustomEvent(
            "PuzzleTimer",
            new Dictionary<string, object>
            {
                {"Puzzle A", _data.timerP1},
                {"Puzzle B", _data.timerP2},
                {"Puzzle C", _data.timerP3},
                {"Puzzle D", _data.timerP4},
                {"Puzzle E", _data.timerP5},
                {"Puzzle F", _data.timerP6},
                {"Final Time", _data.finalTimer}
            });

        var vcTimerResult = Analytics.CustomEvent(
            "VoiceChatTimer",
            new Dictionary<string, object>
            {
                {"Watcher VC Timer", _data.voiceChatTimerWatcher},
                {"Runner A VC Timer", _data.voiceChatTimerRunnerA},
                {"Runner B VC Timer", _data.voiceChatTimerRunnerB},
            });
        
        var vcUsageResult = Analytics.CustomEvent(
            "VoiceChatTimer",
            new Dictionary<string, object>
            {
                {"Watcher VC Usage", _data.voiceChatUsageWatcher},
                {"Runner A VC Usage", _data.voiceChatUsageRunnerA},
                {"Runner B VC Usage", _data.voiceChatUsageRunnerB},
            });
        
        Debug.Log($"Room name Result : {roomName} + {_data.roomName}");
        Debug.Log($"Total time Result : {timeResult} + {_data.finalTimer}");
        Debug.Log($"VC time Result : {vcTimerResult} + {_data.voiceChatTimerWatcher}");
        Debug.Log($"VC usage Result : {vcUsageResult} + {_data.voiceChatUsageWatcher}");

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
