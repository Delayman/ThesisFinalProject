using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatePuzzleControl : Interactable
{
    [Tooltip("Set which object that want to be move")]
    public GameObject movingObj;
    [Tooltip("Set how fast the object will move")]
    [SerializeField] [Range(0.1f, 5f)] private float speed;
    
    private GameObject directionButtons;
    private Rigidbody movingObjRb;
    
    private const string feedbackText = "[E] to <color=red>push</color> the button.";

    private void Start()
    {
        directionButtons = gameObject;
        movingObjRb = movingObj.GetComponent<Rigidbody>();
    }

    public override string GetDescription()
    {
        return feedbackText;
    }

    public override void Interact()
    {
        CheckDirectionButton();
    }

    private void CheckDirectionButton()
    {
        switch (directionButtons.name.Last().ToString())
        {
            case "N" :
                var forward = transform.forward;
                movingObjRb.MovePosition(movingObjRb.position + forward * speed);
                break;
            case "S" :
                var back = transform.forward;
                movingObjRb.MovePosition(movingObjRb.position + -back * speed);
                break;
            case "W" :
                var right = transform.right;
                movingObjRb.MovePosition(movingObjRb.position + -right * speed);
                break;
            case "E" :
                var left = transform.right;
                movingObjRb.MovePosition(movingObjRb.position + left * speed);
                break;
        }
    }
}