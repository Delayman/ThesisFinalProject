using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDistractPos : MonoBehaviour
{
    public static int camID;
    public List<GameObject> CameraList = new List<GameObject>();
    
    [Tooltip("Do NOT put anything in this space")]
    public GameObject chosenCam;

    public void OnPressedPlaySound()
    {
        
        foreach (var cam in CameraList)
        {
            if (cam.name.Contains(camID.ToString()) && cam.active)
            {
                chosenCam = cam;
            }
        }

        var chosenDistractPos = chosenCam.GetComponent<DistractPos>();
        chosenDistractPos.PlaySound();
    }
}
