using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordEnter : Interactable
{
    public TMP_Text passtext;
    private bool isOn;
    public string Ans;
    void Start()
    {
        Ans = "222222";
    }
    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=green>Enter</color> the light.";
        return "Press [E] to turn <color=green>Enter</color> the light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        EnterPass();
    }
    public void EnterPass()
    {
        if (passtext.text == Ans)
        {
            passtext.text = "Correct";
        }
        else
        {
            passtext.text = "";
        }
    }
}
