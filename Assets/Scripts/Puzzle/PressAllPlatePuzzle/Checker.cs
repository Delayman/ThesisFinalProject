using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool isPressed;
    private MeshRenderer objMeshRenderer;
    
    private PressAllPlateController ctr;

    private void Start()
    {
        objMeshRenderer = GetComponent<MeshRenderer>();
        ctr = FindObjectOfType<PressAllPlateController>();
    }

    private void OnTriggerEnter(Collider _col)
    {
        if (!_col.gameObject.CompareTag("ObjectiveObj")) return;
        
        isPressed = !isPressed;
        objMeshRenderer.material.color = isPressed ? Color.green : Color.red;
        ctr.CheckCompleted(this);
    }
}
