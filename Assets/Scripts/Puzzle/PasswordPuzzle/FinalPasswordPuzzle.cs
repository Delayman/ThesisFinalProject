using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FinalPasswordPuzzle : Interactable
{
    private FinalPasswordController ctr;
    
    private const string OffText = "[E] to enter password.";

    private void Awake()
    {
        ctr = GameObject.FindObjectOfType<FinalPasswordController>();
    }

    public override string GetDescription()
    {
        return OffText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddPasswordDigit", RpcTarget.All);
    }

    private void AddPasswordDigit()
    {
        ctr.inputPassword += this.name;
        ctr.CheckCompleted();
    }
}
