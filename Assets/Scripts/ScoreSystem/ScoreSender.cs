using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSender : MonoBehaviour
{
    public static int scoreToBeSend;
    public static float timeToBeSend;

    public void SavedScore(int _savedScore)
    {
        scoreToBeSend = _savedScore;
    }
    
    public void SavedTime(float _savedTime)
    {
        timeToBeSend = _savedTime;
    }
    
}
