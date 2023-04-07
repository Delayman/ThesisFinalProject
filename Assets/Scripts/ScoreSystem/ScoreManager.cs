using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int totalScore = 0;
    public static float totalTime = 0;

    private void FixedUpdate()
    {
        totalTime += Time.deltaTime;
    }

    private void OnDestroy()
    {
        var _tempObj = new GameObject();

        _tempObj.AddComponent<ScoreSender>();
        _tempObj.name = "Saved Score";

        _tempObj.GetComponent<ScoreSender>().SavedScore(totalScore);
        _tempObj.GetComponent<ScoreSender>().SavedTime(Mathf.Round(totalTime));
        DontDestroyOnLoad(_tempObj);
    }
}

    
