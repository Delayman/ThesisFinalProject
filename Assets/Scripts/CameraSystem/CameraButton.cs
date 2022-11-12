using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButton : Interactable
{
    private CameraUIController camUi;
    
    private const string OffText = "[E] to watch the camera.";
    private const string OnText = "";

    private bool isOn;

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
        return isOn ? OffText : OnText;
    }

    public override void Interact()
    {
        isOn = !isOn;

        ToggleCam();
    }

    private void ToggleCam()
    {
        if (isOn)
            camUi.StartCamUI();
        else
            camUi.HideCamUI();
    }
}