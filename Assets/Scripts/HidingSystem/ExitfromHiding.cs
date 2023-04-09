using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitfromHiding : Interactable
{
    private const string OnText = "[E] to get out.";
    private HidingScript hoster;

    public AudioSource HideSound;

    private void Start()
    {
        hoster = GetComponentInParent<HidingScript>();
    }

    public override string GetDescription()
    {
        return OnText;
    }

    public override void Interact()
    {
        GetOut();
    }

    private void GetOut()
    {
        hoster.GetPlayerOut();
        HideSound.Play();
    }
}
