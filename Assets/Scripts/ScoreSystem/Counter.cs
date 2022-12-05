using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [Range(1, 10)] [SerializeField] private int scoreValue = 0;

    private ScoreManager scoreManager;
    
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void AddScore()
    {
        scoreManager.totalScore += scoreValue;
    }
}
