using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalPasswordController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;
    [SerializeField] private TextMeshProUGUI passwordInputField;
    
    [SerializeField] private string correctPassword;
    public string inputPassword;

    private FinalPasswordPuzzle finalBtn;
    
    private bool isCompleted;

    private void Awake()
    {
        correctPassword ??= "1234567";
    }

    private void Start()
    {
        finalBtn = FindObjectOfType<FinalPasswordPuzzle>();
        
        rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
    }

    public void CheckCompleted()
    {
        passwordInputField.text = inputPassword;
            
        if (correctPassword == inputPassword) isCompleted = true;
            
        if (!isCompleted) return;
        
        rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
    }
}
