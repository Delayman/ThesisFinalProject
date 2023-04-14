using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RepairVent : Interactable
{
    [SerializeField] private Timer textBox;
    [SerializeField] private float addedTime = 10f;
    [SerializeField] private float repairTime = 5f;
    
    private RepairPanelController ctr;
    
    private const string ActiveText = "[E] to repair the ventilation.";
    
    private bool isOn;

    public AudioSource Sound;
    private void Awake()
    {
        if (textBox == null) Debug.Log($"<color=red>Timer </color> was NOT FOUND");;
    }

    private void Start()
    {
        ctr = FindObjectOfType<RepairPanelController>();
        isOn = false;
    }

    public override string GetDescription()
    {
        return ActiveText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("Repair", RpcTarget.All);
    }

    [PunRPC]
    private void Repair()
    {
        textBox.isResetting = true;
        ctr.DisableAllButton();
        isOn = true;
        Invoke(nameof(Cooldown), repairTime);
        Sound.Play();
    }

    private void Cooldown()
    {
        ctr.EnableAllButton();
        textBox.AddTime(textBox.maxTimer);
        textBox.isResetting = false;
        textBox.isTimeOut = false;
        isOn = false;
    }
}
