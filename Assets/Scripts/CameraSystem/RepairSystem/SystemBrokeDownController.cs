using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemBrokeDownController : MonoBehaviour
{
    [SerializeField] private GameObject camBrokeUI;
    [SerializeField] private GameObject soundBrokeUI;
    [SerializeField] private List<GameObject> ventBrokeUI;
    
    [SerializeField] private Button lureButton;
    public float delay = 5f;

    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    public void BrokeCam()
    {
        camBrokeUI.SetActive(true);
    }
    
    public void BrokeSound()
    {
        soundBrokeUI.SetActive(true);
        lureButton.interactable = false;
    }
    
    public void BrokeVent()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("BrokeVentRpc", RpcTarget.All);
    }

    [PunRPC]
    public void BrokeVentRpc()
    {
        foreach (var ventUI in ventBrokeUI)
        {
            ventUI.SetActive(true);
        }
    }
    
    public void RepairCam()
    {
        camBrokeUI.SetActive(false);
    }
    
    public void RepairSound()
    {
        soundBrokeUI.SetActive(false);
        lureButton.interactable = true;
    }
    
    public void RepairVent()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("RepairVentRpc", RpcTarget.All);
    }
    
    [PunRPC]
    public void RepairVentRpc()
    {
        foreach (var ventUI in ventBrokeUI)
        {
            ventUI.SetActive(false);
        }
    }
    
    public void RepairAll()
    {
        camBrokeUI.SetActive(false);
        soundBrokeUI.SetActive(false);
        
        foreach (var ventUI in ventBrokeUI)
        {
            ventUI.SetActive(false);
        }
    }

    public IEnumerator LureBtnDelay()
    {
        lureButton.interactable = false;
        yield return new WaitForSeconds(delay);
        lureButton.interactable = true;
    }
}
