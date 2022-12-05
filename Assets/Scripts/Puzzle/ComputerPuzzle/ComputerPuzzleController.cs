using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComputerPuzzleController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;

    private List<CorrectOne> correctObjList;
    private List<WrongOne> wrongObjList;

    private List<bool> checklist;

    private bool isCompleted;
    public GameObject NoComplete;
    public GameObject HaveBeenComplete;

    public CutScenePlay cutplay;
    private void Awake()
    {
        correctObjList ??= new List<CorrectOne>();
        wrongObjList ??= new List<WrongOne>();
        checklist ??= new List<bool>();
    }

    private void Start()
    {
        correctObjList = FindObjectsOfType<CorrectOne>().ToList();
        wrongObjList = FindObjectsOfType<WrongOne>().ToList();
        //rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);
    }

    public void CheckIsItCompleted()
    {
        foreach (var _correctObj in correctObjList)
        {
            if(_correctObj.isActive) isCompleted = true;

            if (!_correctObj.isActive)
            {
                isCompleted = false;
                break;
            }
        }

        foreach (var _wrongObj in wrongObjList)
        {
            if(_wrongObj.isActive) isCompleted = false;
        }

        if (!isCompleted) return;
        NoComplete.SetActive(false);
        HaveBeenComplete.SetActive(true);
        CutScenePlay.PassPuzzle += 1;
        cutplay.CutScene2();
        //rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
    }
}
