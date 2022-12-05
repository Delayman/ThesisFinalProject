using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompleteButton : Interactable
{
    private MazePuzzleController ctr;
        
    private const string OffText = "[E] to press the button.";
    private const string OnText = "";

    public bool isOn;

    
    private void Awake()
    {
        ctr = GameObject.FindObjectOfType<MazePuzzleController>();
    }
    
    public override string GetDescription()
    {
        Debug.Log($"test");
        return OffText;
    }

    public override void Interact()
    {
        isOn = true;

        SetComplete();
    }

    private void SetComplete()
    {
        ctr.CheckCompleted();
    }
}
