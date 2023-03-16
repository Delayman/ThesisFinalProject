using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool isHidden;
    public bool requestHiding;

    private void OnTriggerStay(Collider col)
    {
        if (!col.CompareTag("HidingLocker")) return;
        
        if (Input.GetKey(KeyCode.E))
        {
            requestHiding = true;
        }
    }
}
