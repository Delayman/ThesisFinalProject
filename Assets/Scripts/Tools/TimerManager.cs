using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private float pTimer1,pTimer2,pTimer3,pTimer4,pTimer5,pTimer6;
    public float finpTimer1,finpTimer2,finpTimer3,finpTimer4,finpTimer5,finpTimer6;

    public List<float> pTimerToBeSend;

    private bool isTrigTimer1,isTrigTimer2,isTrigTimer3,isTrigTimer4,isTrigTimer5,isTrigTimer6;

    private void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
    }

    #region TriggerPuzzleTimer

    public void TriggerTimerPuzzleOne()
    {
        if (!isTrigTimer1)
        {
            pTimer1 = ScoreManager.totalTime;
            isTrigTimer1 = !isTrigTimer1;
        }
    }
    
    public void TriggerTimerPuzzleTwo()
    {
        if (!isTrigTimer2)
        {
            pTimer2 = ScoreManager.totalTime;
            isTrigTimer1 = !isTrigTimer1;
        }    
    }
    
    public void TriggerTimerPuzzleThree()
    {
        if (!isTrigTimer3)
        {
            pTimer3 = ScoreManager.totalTime;
            isTrigTimer1 = !isTrigTimer1;

        }
    }
    
    public void TriggerTimerPuzzleFour()
    {
        if (!isTrigTimer4)
        {
            pTimer4 = ScoreManager.totalTime;
            isTrigTimer1 = !isTrigTimer1;
        }

    }
    
    public void TriggerTimerPuzzleFive()
    {
        if (!isTrigTimer5)
        {
            pTimer5 = ScoreManager.totalTime;
            isTrigTimer1 = !isTrigTimer1;
        }

    }

    public void TriggerTimerPuzzleSix()
    {
        if (!isTrigTimer6)
        {
            pTimer6 = ScoreManager.totalTime;
            isTrigTimer1 = !isTrigTimer1;
        }

    }

    #endregion

    #region TriggerCompletedTimer

    public void TriggerCompleteTimerOne()
    { 
        finpTimer1 = Mathf.Round(ScoreManager.totalTime - pTimer1);
    }
    
    public void TriggerCompleteTimerTwo()
    {
        finpTimer2 = Mathf.Round(ScoreManager.totalTime- pTimer2);
    }
    
    public void TriggerCompleteTimerThree()
    {
        finpTimer3 = Mathf.Round(ScoreManager.totalTime- pTimer3);
    }
    
    public void TriggerCompleteTimerFour()
    {
        finpTimer4 = Mathf.Round(ScoreManager.totalTime- pTimer4);
    }
    
    public void TriggerCompleteTimerFive()
    {
        finpTimer5 = Mathf.Round(ScoreManager.totalTime- pTimer5);
    }

    public void TriggerCompleteTimerSix()
    {
        finpTimer6 = Mathf.Round(ScoreManager.totalTime- pTimer6);
    }

    #endregion
}
