using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteButton : Interactable
{
    private MazePuzzleController ctr;
        
    private const string OffText = "[E] to press the button.";
    private const string OnText = "";

    public bool isOn;
    
    private void Awake()
    {
        ctr = FindObjectOfType<MazePuzzleController>();
    }
    
    public override string GetDescription()
    {
        return !isOn ? OffText : OnText;
    }

    public override void Interact()
    {
        isOn = true;

        SetComplete();
    }

    private void SetComplete()
    {
        Debug.Log($"Test");
        ctr.CheckCompleted();
    }
}
