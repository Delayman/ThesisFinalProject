using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemBrokeDownController : MonoBehaviour
{
    [SerializeField] private GameObject camBrokeUI;
    [SerializeField] private GameObject soundBrokeUI;
    [SerializeField] private GameObject ventBrokeUI;
    
    [SerializeField] private Button lureButton;

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
        ventBrokeUI.SetActive(true);
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
        ventBrokeUI.SetActive(false);
    }
    
    public void RepairAll()
    {
        camBrokeUI.SetActive(false);
        soundBrokeUI.SetActive(false);
        ventBrokeUI.SetActive(false);
    }
}
