using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePuzzleController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;

    private IcePuzzleGoal goal;
    private bool isCompleted;
    
    private void Start()
    {
        goal = FindObjectOfType<IcePuzzleGoal>();
        
        rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
    }

    public void CheckComplete()
    {
        isCompleted = goal.isEnterGoal;
        
        if (!isCompleted) return;
        rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
    }
    
}
