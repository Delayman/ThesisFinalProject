using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerActivator : MonoBehaviour
{
    [Range(1,6)] public int PuzzleNum = 0;
    
    private TimerManager timer;
        
    private void Start()
    {
        timer = FindObjectOfType<TimerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (PuzzleNum)
            {
                case 1 : timer.TriggerTimerPuzzleOne(); break;
                case 2 : timer.TriggerTimerPuzzleTwo(); break;
                case 3 : timer.TriggerTimerPuzzleThree(); break;
                case 4 : timer.TriggerTimerPuzzleFour(); break;
                case 5 : timer.TriggerTimerPuzzleFive(); break;
                case 6 : timer.TriggerTimerPuzzleSix(); break;
            }
        }
    }
}
