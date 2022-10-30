using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : Interactable
{
    private GameObject receiver;
    private bool buttonState;
    
    private PressAllButtonPuzzleController ctr;
    
    private const string OffText = "[E] to turn <color=red>off</color> the switch.";
    private const string ActivatedText = "This button is already actived";

    public bool isOn;

    private void Start()
    {
        receiver = gameObject;
        receiver.SetActive(buttonState);

        ctr = FindObjectOfType<PressAllButtonPuzzleController>();
    }

    public override string GetDescription()
    {
        return !isOn ? OffText : ActivatedText;
    }

    public override void Interact()
    {
        isOn = true;
        ctr.CheckCompleted();
    }
}
