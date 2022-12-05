using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int totalScore = 0;

    private void OnDestroy()
    {
        var _tempObj = new GameObject();

        _tempObj.AddComponent<ScoreSender>();
        _tempObj.name = "Saved Score";

        _tempObj.GetComponent<ScoreSender>().SavedScore(totalScore);
        DontDestroyOnLoad(_tempObj);
    }
}

    
