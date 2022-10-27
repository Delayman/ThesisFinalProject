using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressAllPlateController : MonoBehaviour
{
    [SerializeField] private GameObject rewardPrefab;
    
    private Checker checker;
    private List<Checker> activatedList;
    private List<bool> checkList;
    
    private bool isCompleted;

    private void Awake()
    {
        activatedList ??= new List<Checker>();
        checkList ??= new List<bool>();
    }

    private void Start()
    {
        activatedList = FindObjectsOfType<Checker>().ToList();
    }

    public void CheckCompleted(Checker _checker)
    {
        checker = _checker;
        
        if (checker.isPressed)
        {
            checkList.Add(checker.isPressed);
            isCompleted = true;
        }

        if (!_checker.isPressed)
        {
            ResetThisPuzzle();
        }
        
        if (checkList.Count == activatedList.Count && isCompleted)
        {
            rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void ResetThisPuzzle()
    {
        isCompleted = false;
        checkList.Clear();
        ResetColor();
    }

    private void ResetColor()
    {
        foreach (var _obj in activatedList)
        {
            _obj.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            _obj.isPressed = false;
        }
    }
}
