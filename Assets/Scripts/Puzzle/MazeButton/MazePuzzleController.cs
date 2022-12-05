using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzleController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;
    
    private MazeButton completeBtn;

    private bool isCompleted;
    // public GameObject NoComplete;
    // public GameObject HaveBeenComplete;
    public GameObject NoComplete;
    public GameObject HaveBeenComplete;
    public CutScenePlay cutplay;
    private void Start()
    {
        completeBtn = FindObjectOfType<MazeButton>();
        
        //rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);
    }

    public void CheckCompleted()
    {
        if (completeBtn.isOn)
            isCompleted = true;
        
        if (!isCompleted) return;
        
       // rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
        NoComplete.SetActive(false);
        HaveBeenComplete.SetActive(true);
        CutScenePlay.PassPuzzle += 1;
        cutplay.CutScene2();
    }
}
