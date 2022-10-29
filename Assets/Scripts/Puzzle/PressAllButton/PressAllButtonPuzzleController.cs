using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressAllButtonPuzzleController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;
    
    private List<Receiver> reciverActivedList;

    private bool isCompleted;

    private void Awake()
    {
        reciverActivedList ??= new List<Receiver>();
    }

    private void Start()
    {
        reciverActivedList = Resources.FindObjectsOfTypeAll<Receiver>().ToList();
        
        rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
    }

    public void CheckCompleted()
    {
        foreach (var _correctObj in reciverActivedList)
        {
            if (!_correctObj.isOn)
            {
                isCompleted = false;
                break;
            }
            
            if(_correctObj.isOn) isCompleted = true;
        }
        
        if (!isCompleted) return;
        rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
    }
    
}
