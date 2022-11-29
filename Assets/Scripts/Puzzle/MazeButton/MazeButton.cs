using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeButton : Interactable
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
