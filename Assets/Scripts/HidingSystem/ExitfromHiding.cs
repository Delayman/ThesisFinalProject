using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ExitfromHiding : Interactable
{
    private const string OnText = "[E] to get out.";
    private HidingScript hideBox;

    public AudioSource HideSound;

    private void Start()
    {
        hideBox = GetComponentInParent<HidingScript>();
    }

    public override string GetDescription()
    {
        return OnText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("GetOut", RpcTarget.All);
    }
    
    [PunRPC]
    private void GetOut()
    {
        hideBox.GetPlayerOut();
        HideSound.Play();
    }
}
