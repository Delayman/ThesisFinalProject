using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DataPoster : MonoBehaviour
{
    private void Start()
    {
        // var _data = FindObjectOfType<AnalyticSender>();
        // var result = Analytics.CustomEvent(
        //     "PuzzleTimer",
        //     new Dictionary<string, object>
        //     {
        //         {"Puzzle A", AnalyticSender.puzzleTimer[0]},
        //         {"Puzzle B", AnalyticSender.puzzleTimer[1]},
        //         {"Puzzle C", AnalyticSender.puzzleTimer[2]},
        //         {"Puzzle D", AnalyticSender.puzzleTimer[3]},
        //         {"Puzzle E", AnalyticSender.puzzleTimer[4]},
        //         {"Puzzle F", AnalyticSender.puzzleTimer[5]},
        //         {"Final Time", AnalyticSender.finalTimer}
        //     });
        
        var _data = FindObjectOfType<Analytic>();
        //For dummies testing ONLY
        var result = Analytics.CustomEvent(
            "PuzzleTimer",
            new Dictionary<string, object>
            {
                {"PuzzleA", _data.timerTP1},
                {"PuzzleB", _data.timerTP2},
                {"PuzzleC", _data.timerTP3},
                {"PuzzleD", _data.timerTP4},
                {"PuzzleE", _data.timerTP5},
                {"PuzzleF", _data.timerTP6},
                {"FinalTime", _data.finalTTimer}
            });
        
        Debug.Log($"Analytic Result : {result} + {_data.finalTTimer}");
        
        var resultB = Analytics.CustomEvent(
                    "PuzzleTimerChecker",
                    new Dictionary<string, object>
                    {
                        {"PuzzleA", _data.timerTP1},
                        {"PuzzleB", _data.timerTP2},
                        {"PuzzleC", _data.timerTP3},
                        {"PuzzleD", _data.timerTP4},
                        {"PuzzleE", _data.timerTP5},
                        {"PuzzleF", _data.timerTP6},
                        {"FinalTime", _data.finalTTimer}
                    });
                
                Debug.Log($"Analytic Result : {resultB} + {_data.timerTP6}");
    }
}
