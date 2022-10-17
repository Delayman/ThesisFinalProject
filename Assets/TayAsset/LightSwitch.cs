using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public GameObject a;
    public Light m_Light; // im using m_Light name since 'light' is already a variable used by unity
    public bool isOn;
    //public static bool Blue;
    private void Start()
    {
        UpdateLight();
    }

    void UpdateLight()
    {
        m_Light.enabled = isOn;
        a.SetActive(isOn);
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=red>off</color> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        UpdateLight();
        // scritp.num = num*1
      /*  if (a.transform.name == "")
        {

        }*/
    }
}
