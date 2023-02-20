using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ComputerPuzzle : Interactable
{
    [Tooltip("Set the look of object when toggled button")] [SerializeField] 
    //private Mesh toggledMesh;
    //private Mesh oldMesh;

    private ComputerPuzzleController ctr;
    private MeshFilter objMeshFilter;

    private bool isOn;

    private const string OffText = "[E] to turn <color=red>off</color> the switch.";
    private const string OnText = "[E] to turn <color=green>on</color> the switch.";

    private CorrectOne correctOne;
    private WrongOne wrongOne;

    public GameObject ChangeScreen;
    public GameObject DefultScreen;

    public GameObject ScreenLight;
    private void Start()
    {
        objMeshFilter = GetComponent<MeshFilter>();
    //    oldMesh = GetComponent<MeshFilter>().mesh;
        ctr = FindObjectOfType<ComputerPuzzleController>();
        
        if (GetComponent<CorrectOne>() != null)
        {
            correctOne = GetComponent<CorrectOne>();
        }
        
        if (GetComponent<WrongOne>() != null)
        {
            wrongOne = GetComponent<WrongOne>();
        }
        ScreenLight.SetActive(false);
    }

    public override string GetDescription()
    {
        return isOn ? OffText : OnText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("ToggleComSwitch", RpcTarget.All);
    }

    [PunRPC]
    private void ToggleComSwitch()
    {
        isOn = !isOn;
        
        //objMeshFilter.mesh = isOn ? toggledMesh : oldMesh;
        if (isOn)
        {
            DefultScreen.GetComponent<Renderer>().material.color = Color.white;
            ScreenLight.SetActive(true);
        }
        else
        {
            DefultScreen.GetComponent<Renderer>().material.color = Color.black;
            ScreenLight.SetActive(false);
        }

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
