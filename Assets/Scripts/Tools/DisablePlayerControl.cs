using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerControl : MonoBehaviour
{
    public bool isDisable;

    private FPS_PlayerMovement fps;
    private PlayerInteraction interaction;
    private GameObject disableUI;

    private void Update()
    {
        if (!Application.isPlaying) return;

        if (fps == null && interaction == null)
        {
            fps = GetComponent<FPS_PlayerMovement>();
            interaction = GetComponent<PlayerInteraction>();
            disableUI = GameObject.FindWithTag("MainUI");
        }
        
        if (isDisable)
        {
            fps.enabled = false;
            interaction.enabled = false;
            disableUI.SetActive(false);
        }
        else
        {
            fps.enabled = true;
            interaction.enabled = true;
            disableUI.SetActive(true);
        }
    }
}
