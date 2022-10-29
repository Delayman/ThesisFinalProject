using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathPuzzleController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;
    
    [Tooltip("Set the answer")] [SerializeField]
    private float answer = 15f;

    [Tooltip("Set the TMP Box of answer")] [SerializeField]
    private TextMeshProUGUI answerBox;
    
    private float tempNum;
    private bool isCompleted;
    
    private void Start()
    {
        rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
    }
    
    public void CheckAnswer()
    {
        tempNum = float.Parse(answerBox.text);

        if (tempNum == answer) isCompleted = true;
        CheckCompleted();
    }

    private void CheckCompleted()
    {
        if (!isCompleted) return;
        rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
    }

}