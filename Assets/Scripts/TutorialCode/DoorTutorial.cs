using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTutorial : Interactable
{
    public GameObject cuttutor;
    public bool isOn;
    //public static bool Blue;
    public AudioSource ButtonDoorSound;
    private void Start()
    {
        cuttutor.SetActive(false);
    }

    public override string GetDescription()
    {
        return "Press [E] to open the door";
    }

    public override void Interact()
    {
        isOn = !isOn;
        Soundplay();
        cuttutor.SetActive(true);
    }
    public void Soundplay()
    {
        ButtonDoorSound.Play();
    }
}
