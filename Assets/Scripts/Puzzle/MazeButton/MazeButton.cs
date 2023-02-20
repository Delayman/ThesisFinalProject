using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MazeButton : Interactable
{
    private MazePuzzleController ctr;
        
    private const string OffText = "[E] to press the button.";
    private const string OnText = "";

    public bool isOn;
    
    private void Awake()
    {
        ctr = FindObjectOfType<MazePuzzleController>();
    }
    
    public override string GetDescription()
    {
        return OffText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("SetMazeComplete", RpcTarget.All);
    }
    
    [PunRPC]
    private void SetMazeComplete()
    {
        isOn = true;

        ctr.CheckCompleted();
    }
}
