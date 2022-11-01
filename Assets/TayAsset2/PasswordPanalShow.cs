using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordPanalShow : Interactable
{
    public GameObject CheckPuzzle;
    public bool isOn;
    //public static bool Blue;
    private void Start()
    {
        ShowPanalPass();
    }

    void ShowPanalPass()
    {
       
        CheckPuzzle.SetActive(isOn);
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=red>off</color> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        ShowPanalPass();
        // scritp.num = num*1
        /*  if (a.transform.name == "")
          {

          }*/
    }
}
