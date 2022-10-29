using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DivideButton : Interactable
{
    private string OffText = "[E] to <color=red>use</color> button";
    private const string ActivatedText = "This button is already actived";
    
    [Tooltip("Set starting state of value")]
    public float state = 1;
    [Tooltip("Value for divide (Ex. 1/VALUE)")]
    public float divideNum;

    private bool isOn;

    private ResultText resultText;

    private void Start()
    {
        resultText = FindObjectOfType<ResultText>();
        state = 1;
        divideNum = 2;
    }

    public override string GetDescription()
    {
        return !isOn ? OffText : ActivatedText;
    }

    public override void Interact()
    {
        isOn = true;
        GetTextBox();
    }

    private void GetTextBox()
    {
        resultText.UpdateText(state);
        resultText.DivideState(divideNum);
        resultText.ChangeStateToAll(divideNum);
    }
}
