using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class IcePuzzleReset : Interactable
{
    private IcePuzzle icePuzzle;
    private Vector3 originPos; 
    private const string resetText = "[E] to <color=red>reset</color> this puzzle.";

    public AudioSource ButtonOBJ;

    private void Start()
    {
        icePuzzle = FindObjectOfType<IcePuzzle>();
        originPos = icePuzzle.movingObj.transform.position;
    }

    public override string GetDescription()
    {
        return resetText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("ResetIcePos", RpcTarget.All);
        
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }

    [PunRPC]
    public void ResetIcePos()
    {
        icePuzzle.movingObj.transform.position = originPos;
        
    }
}
