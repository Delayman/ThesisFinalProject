using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ComputerPuzzle : Interactable
{
    [SerializeField] private Mesh toggledMesh;
    private Mesh oldMesh;

    private ComputerPuzzleController ctr;
    private MeshFilter objMeshFilter;

    private bool isOn;

    private const string OffText = "[E] to turn <color=red>off</color> the switch.";
    private const string OnText = "[E] to turn <color=green>on</color> the switch.";

    private CorrectOne correctOne;
    private WrongOne wrongOne;

    private void Start()
    {
        objMeshFilter = GetComponent<MeshFilter>();
        oldMesh = GetComponent<MeshFilter>().mesh;
        ctr = FindObjectOfType<ComputerPuzzleController>();
        
        if (GetComponent<CorrectOne>() != null)
        {
            correctOne = GetComponent<CorrectOne>();
        }
        
        if (GetComponent<WrongOne>() != null)
        {
            wrongOne = GetComponent<WrongOne>();
        }
    }

    public override string GetDescription()
    {
        return isOn ? OffText : OnText;
    }

    public override void Interact()
    {
        isOn = !isOn;

        ToggleSwitch();
    }

    private void ToggleSwitch()
    {
        objMeshFilter.mesh = isOn ? toggledMesh : oldMesh;

        if (correctOne != null)
        {
            correctOne.isActive = isOn;
        }

        if (wrongOne != null)
        {
            wrongOne.isActive = isOn;
        }

        ctr.CheckIsItCompleted();
    }
}
