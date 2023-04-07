using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticSender : MonoBehaviour
{
    public static float finalTimer;
    public static List<float> puzzleTimer;

    public void SavedFinalTimer(float _savedFinalTimer)
    {
        finalTimer = _savedFinalTimer;
    }
    
    public void SavedTime(List<float> _pTimer)
    {
        puzzleTimer = _pTimer;
    }
}
