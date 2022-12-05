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

    public GameObject NoComplete;
    public GameObject HaveBeenComplete;

    private bool isCompleted;

    public int maxtext;

    private void Awake()
    {
        correctPassword ??= "1234567";
    }

    private void Start()
    {
        finalBtn = FindObjectOfType<FinalPasswordPuzzle>();
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);

        // rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
    }

    public void CheckCompleted()
    {
        if (passwordInputField.text.Length < 6)
        {
            passwordInputField.text = inputPassword;

            if (correctPassword == inputPassword) isCompleted = true;

            if (!isCompleted) return;

            NoComplete.SetActive(false);
            HaveBeenComplete.SetActive(true);
            passwordInputField.text = "PASS";
        }
        if (passwordInputField.text.Length > 5)
        {
            inputPassword = "";
            passwordInputField.text = inputPassword;
        }
     
        //rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
    }
}
