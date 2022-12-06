using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DisablePlayerControl : MonoBehaviour
{
    [FormerlySerializedAs("isDisable")] public bool isDisableControlAndCam;
    public bool isDisableUI;
    public bool isDisableInteraction;

    private FPS_PlayerMovement fps;
    private PlayerInteraction interaction;
    private GameObject DisUI;

    private void Update()
    {
        if (!Application.isPlaying) return;

        if (fps == null && interaction == null)
        {
            fps = GetComponent<FPS_PlayerMovement>();
            interaction = GetComponent<PlayerInteraction>();
            DisUI = GameObject.FindWithTag("MainUI");
        }
        
        fps.enabled = !isDisableControlAndCam;
        
        interaction.enabled = !isDisableInteraction;

        DisUI.SetActive(!isDisableUI);
    }
}
