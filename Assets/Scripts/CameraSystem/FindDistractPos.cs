using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FindDistractPos : MonoBehaviour
{
    public static int camID;
    public List<GameObject> CameraList = new List<GameObject>();
    
    [Tooltip("Do NOT put anything in this space")]
    public GameObject chosenCam;

    public void OnPressedPlaySound()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("Lure", RpcTarget.All);

        var lureBtn = FindObjectOfType<SystemBrokeDownController>();
        StartCoroutine(lureBtn.LureBtnDelay());
    }

    [PunRPC]
    public void Lure()
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
