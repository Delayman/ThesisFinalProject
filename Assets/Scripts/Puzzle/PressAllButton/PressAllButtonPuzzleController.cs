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

    public GameObject NoComplete;
    public GameObject HaveBeenComplete;
    public CutScenePlay cutplay;
    public GameObject FinalPuzzleActive;
    public GameObject FinalHint;
    
    private TimerManager timer;
    public AudioSource Winsound;
    private void Awake()
    {
        reciverActivedList ??= new List<Receiver>();
    }

    private void Start()
    {
        reciverActivedList = Resources.FindObjectsOfTypeAll<Receiver>().ToList();
        
       // rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);
        FinalPuzzleActive.SetActive(false);
        FinalHint.SetActive(false);
        timer = FindObjectOfType<TimerManager>();

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
        // rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
        NoComplete.SetActive(false);
        HaveBeenComplete.SetActive(true);
        FinalPuzzleActive.SetActive(true);
        Winsound.Play();
        var counter = GetComponentInParent<Counter>();
        counter.AddScore();
        cutplay.CutScene4();
        FinalHint.SetActive(true);
        timer.TriggerCompleteTimerThree();

    }

}
