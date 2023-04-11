using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class DivideButton : Interactable
{
    private string OffText = "[E] to <color=red>use</color> button";
    private const string ActivatedText = "This button is already actived";
    
    [Tooltip("Set starting state of value")]
    public float state = 1;
    [Tooltip("Value for divide (Ex. 1/VALUE)")]
    public float divideNum = 2;

    private bool isOn;

    private ResultText resultText;

    public AudioSource ButtonOBJ;

    private void Awake()
    {
        state = 1;
        divideNum = 2;
    }

    private void Start()
    {
        resultText = FindObjectOfType<ResultText>();
        state = 1;
        divideNum = 2;
        
        // Debug.Log($"state : {state} | mulNum : {divideNum}");
    }

    public override string GetDescription()
    {
        return !isOn ? OffText : ActivatedText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("GetTextBoxDiv", RpcTarget.All);
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }

    [PunRPC]
    private void GetTextBoxDiv()
    {
        isOn = true;
        
        resultText.UpdateText(state);
        resultText.DivideState(divideNum);
        resultText.ChangeStateToAll(divideNum);
        Debug.Log($"state : {state} | mulNum : {divideNum}");
    }
}
