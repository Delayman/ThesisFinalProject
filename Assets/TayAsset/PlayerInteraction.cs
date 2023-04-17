using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;

    public TextMeshProUGUI interactionText;
    
    private PhotonView _view;

    // public GameObject interactionHoldGO; // the ui parent to disable when not interacting
    // public UnityEngine.UI.Image interactionHoldProgress; // the progress bar for hold interaction type

    public Camera cam;

    private void Start()
    {
        _view = GetComponent<PhotonView>();

        if (_view.IsMine)
        {
            interactionText = GameObject.FindGameObjectWithTag("InteractTextField").GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        var ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        var successfulHit = false;

        if (Physics.Raycast(ray, out var _hit, interactionDistance))
        {
            var interactable = _hit.collider.GetComponent<Interactable>();
            var objCheck = _hit.collider.gameObject;
            
             // Debug.Log($"Looking at {objCheck.gameObject.name}");
             // Debug.Log($"Interact at {interactable.gameObject.name}");
            
            if (interactable != null && interactionText != null)
            {
                interactionText.text = interactable.GetDescription();
                HandleInteraction(interactable);
                successfulHit = true;

               // interactionHoldGO.SetActive(interactable.interactionType == Interactable.InteractionType.Hold);
            }
        }

        // if we miss, hide the UI
        if (!successfulHit && interactionText != null)
        {
            interactionText.text = "";
            //interactionHoldGO.SetActive(false);
        }
    }

    private void HandleInteraction(Interactable interactable)
    {
        const KeyCode key = KeyCode.E;

        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                // interaction type is click and we clicked the button -> interact
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    // we are holding the key, increase the timer until we reach 1f
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > 1f) 
                    {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                // interactionHoldProgress.fillAmount = interactable.GetHoldTime();
                break;
            // helpful error for us in the future
            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}
