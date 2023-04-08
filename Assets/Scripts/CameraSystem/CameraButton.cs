using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CameraButton : Interactable
{
    private CameraUIController camUi;
    
    private const string OffText = "[E] to watch the camera.";
    private const string OnText = "";

    public bool isOn;
    
    private List<PlayerInteraction> playerList;

    private DisablePlayerControl targetPlayer;

    public GameObject ESC;
    public AudioSource ButtonOBJ;

    private void Awake()
    {
        camUi = FindObjectOfType<CameraUIController>();
    }

    private void Start()
    {
        isOn = false;
        
        if(camUi == null) Debug.Log($"<color=red>Camera UI Controller </color> was NOT FOUND");
    }

    public override string GetDescription()
    {
        return isOn ? OnText : OffText;
    }

    public override void Interact()
    {
        isOn = !isOn;
        if (targetPlayer == null)
        {
            GetPlayer();
        }
        
        ToggleCam();
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }

    private void GetPlayer()
    {
        playerList = FindObjectsOfType<PlayerInteraction>().ToList();

        foreach (var player in playerList)
        {
            var distance = Vector3.Distance(player.transform.position,this.transform.position);

            if (distance < 10f)
            {
                targetPlayer = player.gameObject.GetComponent<DisablePlayerControl>();
            }
        }
    }

    public void ToggleCam()
    {
        if (isOn)
        {
            ESC.SetActive(false);
            camUi.StartCamUI();
            targetPlayer.isDisableControlAndCam = true;
            
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible= true;
           
        }
        else
        {
            ESC.SetActive(true);
            targetPlayer.isDisableControlAndCam = false;
           
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible= false;
            
        }
    }
}