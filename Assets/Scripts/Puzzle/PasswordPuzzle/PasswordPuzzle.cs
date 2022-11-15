using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordPuzzle : Interactable
{
    public TMP_Text passtext;
    public int num;
    private bool isOn;
    public int maxtext;
    // Start is called before the first frame update
    void Start()
    {
        passtext.text = "";
        maxtext = 5;
    }
    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=green>" + (num)+"</color> the light.";
        return "Press [E] to turn <color=green>" + (num) + "</color> the light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        PasswordShowText();
    }
    public void PasswordShowText()
    {
        if (passtext.text.Length <= maxtext )
        {
            passtext.text += num.ToString();
        }
        else
        {
            passtext.text = "";
        }
    }
}

    
