using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class Activator : Interactable
{
    private List<Receiver> receivers;

    private const string OffText = "[E] to turn <color=red>off</color> the switch.";
    private const string ActivatedText = "This button is already actived";

    private bool isOn;
    public CutScenePlay cutplay;
    public GameObject buttonlight;

    public AudioSource ButtonOBJ;
    private void Awake()
    {
        receivers ??= new List<Receiver>();
    }

    private void Start()
    {
        receivers = Resources.FindObjectsOfTypeAll<Receiver>().ToList();
        buttonlight.SetActive(false);
    }

    public override string GetDescription()
    {
        return !isOn ? OffText : ActivatedText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("ToggleActivatorSwitch", RpcTarget.All);
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }

    [PunRPC]
    private void ToggleActivatorSwitch()
    {
        isOn = true;

        foreach (var _receiver in receivers)
        {
            _receiver.gameObject.SetActive(true);
        }
        buttonlight.SetActive(true);

        cutplay.CutScene3();
    }
}
