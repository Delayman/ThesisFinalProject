using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplyButton : Interactable
{
    private string OffText = "[E] to <color=red>use</color> button";
    private const string ActivatedText = "This button is already actived";
    
    [Tooltip("Set starting state of value")]
    public float state = 1;
    [Tooltip("Value for multiply (Ex. 1 * VALUE)")]
    public float multiplyNum;

    private bool isOn;

    private ResultText resultText;

    private void Start()
    {
        resultText = FindObjectOfType<ResultText>();
        state = 1;
        multiplyNum = state + 1;
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
        resultText.MultiplyState(multiplyNum);
        resultText.ChangeStateToAll(multiplyNum);
    }
}
