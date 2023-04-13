using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class IcePuzzle : Interactable
{
    [Tooltip("Set which object that want to be move")]
    public GameObject movingObj;
    [Tooltip("Set how fast the object will move")]
    [SerializeField] [Range(10f, 10000000f)] private float force;
    
    private GameObject directionButtons;
    private Rigidbody movingObjRb;
    private IcePuzzleGoal goal;
    private IcePuzzleController ctrl;

    public AudioSource ButtonOBJ;

    private const string feedbackText = "[E] to <color=red>push</color> the button.";

    private void Start()
    {
        directionButtons = gameObject;
        movingObjRb = movingObj.GetComponent<Rigidbody>();
        goal = FindObjectOfType<IcePuzzleGoal>();
        ctrl = FindObjectOfType<IcePuzzleController>();
    }

    public override string GetDescription()
    {
        return feedbackText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("CheckDirectionButton", RpcTarget.All); 
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }

    [PunRPC]
    private void CheckDirectionButton()
    {
        switch (directionButtons.name.Last().ToString())
        {
            case "N" :
                movingObjRb.AddForce(transform.forward * force);
                StartCoroutine(ctrl.IceButtonDelay());
                break;
            case "S" :
                movingObjRb.AddForce(-transform.forward * force);
                StartCoroutine(ctrl.IceButtonDelay());
                break;
            case "W" :
                movingObjRb.AddForce(-transform.right * force);
                StartCoroutine(ctrl.IceButtonDelay());
                break;
            case "E" :
                movingObjRb.AddForce(transform.right * force);
                StartCoroutine(ctrl.IceButtonDelay());
                break;
        }
    }
}
