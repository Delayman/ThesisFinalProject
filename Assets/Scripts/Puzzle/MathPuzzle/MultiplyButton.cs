using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class MultiplyButton : Interactable
{
    private string OffText = "[E] to <color=red>use</color> button";
    private const string ActivatedText = "This button is already actived";
    
    [Tooltip("Set starting state of value")]
    public float state = 1;
    [Tooltip("Value for multiply (Ex. 1 * VALUE)")]
    public float multiplyNum;

    private bool isOn;

    private ResultText resultText;
    public AudioSource ButtonOBJ;

    private void Start()
    {
        resultText = FindObjectOfType<ResultText>();
        state = 1;
        multiplyNum = state + 1;
    }

    public override string GetDescription()
    {
        return !isOn ? OffText : ActivatedText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("GetTextBoxMul", RpcTarget.All);
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }

    [PunRPC]
    private void GetTextBoxMul()
    {
        isOn = true;

        resultText.UpdateText(state);
        resultText.MultiplyState(multiplyNum);
        resultText.ChangeStateToAll(multiplyNum);
    }
}
