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
        if (!_view.IsMine) return;

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
        if (!_view.IsMine) return;

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
}
