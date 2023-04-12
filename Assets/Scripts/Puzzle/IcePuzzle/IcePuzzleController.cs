using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePuzzleController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;

    private IcePuzzleGoal goal;
    private bool isCompleted;
    private bool isDisableAfterCompleted;

    public GameObject NoComplete;
    public GameObject HaveBeenComplete;
    public CutScenePlay cutplay;
    
    private TimerManager timer;
    public AudioSource Winsound;
    private void Start()
    {
        goal = FindObjectOfType<IcePuzzleGoal>();
        
        //rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);
        
        
        timer = FindObjectOfType<TimerManager>();

    }

    public void CheckComplete()
    {
        isCompleted = goal.isEnterGoal;
        
        if (!isCompleted || isDisableAfterCompleted) return;

        //rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
        NoComplete.SetActive(false);
        HaveBeenComplete.SetActive(true);
        Winsound.Play();
        CutScenePlay.PassPuzzle += 1;
        cutplay.CutScene2();
        var counter = GetComponentInParent<Counter>();
        counter.AddScore();
        timer.TriggerCompleteTimerFive();
        isDisableAfterCompleted = true;

    }
    
}
